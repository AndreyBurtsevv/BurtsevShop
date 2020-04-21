﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson19_1.Models;
using Lesson19_1.Models.Basket;
using Lesson19_1.Models.Brand;
using Lesson19_1.Models.Model;
using Lesson19_1.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson19_1.Controllers
{
    public class ShopController : Controller
    {
        private readonly IModelService _modelService;

        private readonly IBasketService _basketService;

        public ShopController(IModelService modelService, IBasketService basketService)
        {
            _modelService = modelService;
            _basketService = basketService;
 
        }

        public async Task<IActionResult> Index()
        {
            var models = await _modelService.GetModelsAsync();
            return View(models);
        }

 
        public async Task<IActionResult> AboutProduct(int id)
        {
            var data = await _modelService.GetModelAsync(id);
            return View(data);
        }
 
        public async Task<IActionResult> AddToBasket(int id)
        {
            var data = await _modelService.GetModelAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(CreateBasket create)
        {
            var data = await _modelService.GetModelAsync(create.Id);
            await _basketService.AddToBasketAsync(new CreateBasket { ModelDataId = data.Id, Decriprion = create.Decriprion});
            return Redirect("~/Shop/Index");
        }

        public async Task<IActionResult> Basket()
        {
            var inBasket = await _basketService.GetBasketAsync();
            return View(inBasket);
        }

        public async Task<IActionResult> DeleteFromBasket(int id)
        {
            await _basketService.DeleteModelAsync(id);
            return Redirect("~/Shop/Basket");
        }

    }
}