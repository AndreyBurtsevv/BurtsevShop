using Lesson19_1.DataModels;
using Lesson19_1.Models.Basket;
using Lesson19_1.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Services
{
    public interface IOrderService
    {
        Task<IList<OrderData>> GetOrdersAsync(string userId);

        Task AddOrdersAsymc(string desc, DateTime dateTime, string userId);
    }
}
