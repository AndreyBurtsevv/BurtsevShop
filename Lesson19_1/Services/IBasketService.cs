﻿using Lesson19_1.Models.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Services
{
    public interface IBasketService
    {
        Task<IList<BasketResponse>> GetBasketAsync(string userId);

        Task AddToBasketAsync(CreateBasket model);

        Task DeleteProductAsync(int id);

        Task DeleteAllAsync();
    }
}
