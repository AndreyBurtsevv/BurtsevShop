using AutoMapper;
using Lesson19_1.DataModels;
using Lesson19_1.Models.Basket;
using Lesson19_1.Models.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Services
{
    public class OrderService : IOrderService
    {
        private readonly MyDbContext _dbContext;

        private readonly IMapper _mapper;

        private readonly IBasketService _basketService;

        public OrderService(MyDbContext dbContext, IMapper mapper, IBasketService basketService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _basketService = basketService;
        }

        public async Task AddOrdersAsymc(string desc, DateTime dateTime, string userId)
        {
            var orders = await _basketService.GetBasketAsync(userId);

            foreach (var item in orders)
            {
                var data = new OrderData { UserId = userId, BrandName = item.ModelData.BrandData.Name, ModelName = item.ModelData.Name, Description = desc, Date = dateTime};
                await _dbContext.OrderData.AddAsync(data);
            }

            await _basketService.DeleteAllAsync();

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<OrderData>> GetOrdersAsync(string userId)
        {
           // IList<OrderResponse> result = null;

            var data = await _dbContext.OrderData.Where(x => x.UserId == userId).ToListAsync();

            // result = _mapper.Map<IList<OrderResponse>>(data);

            //  return result;

            return data;
        }
    }
}
