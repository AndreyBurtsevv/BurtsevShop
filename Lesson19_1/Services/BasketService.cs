using AutoMapper;
using Lesson19_1.DataModels;
using Lesson19_1.Models.Basket;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Services
{
    public class BasketService : IBasketService
    {
        private readonly MyDbContext _dbContext;

        private readonly IMapper _mapper;

        public BasketService(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddToBasketAsync(CreateBasket model)
        {
            var data = new BasketData { ModelDataId = model.ModelDataId, Description = model.Decriprion };

            await _dbContext.BasketData.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            var data = await _dbContext.BasketData.Include(b => b.ModelData).Include(b => b.ModelData.BrandData).ToListAsync();
            _dbContext.BasketData.RemoveRange(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            _dbContext.BasketData.Remove(new BasketData { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<BasketResponse>> GetBasketAsync()
        {
            IList<BasketResponse> result = null;

            var data = await _dbContext.BasketData.Include(b => b.ModelData).Include(b=>b.ModelData.BrandData).ToListAsync();

            result = _mapper.Map<IList<BasketResponse>>(data);

            return result;
        }
    }
}
 