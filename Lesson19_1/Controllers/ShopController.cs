using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Lesson19_1.Models;
using Lesson19_1.Models.Basket;
using Lesson19_1.Models.Brand;
using Lesson19_1.Models.Model;
using Lesson19_1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson19_1.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly IModelService _modelService;

        private readonly IBasketService _basketService;

        private readonly IOrderService _orderService;

        public ShopController(IModelService modelService, IBasketService basketService, IOrderService orderService)
        {
            _modelService = modelService;
            _basketService = basketService;
            _orderService = orderService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var models = await _modelService.GetModelsAsync();
            return View(models);
        }

        [AllowAnonymous]
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
            string userIdValue = GetUserId();
            var data = await _modelService.GetModelAsync(create.Id);
            await _basketService.AddToBasketAsync(new CreateBasket { UserId = userIdValue, ModelDataId = data.Id, Decriprion = create.Decriprion });
            return Redirect("~/Shop/Index");
        }

        private string GetUserId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userIdValue = null;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    userIdValue = userIdClaim.Value;
                }
            }
            return userIdValue;
        }

        public async Task<IActionResult> Basket()
        {
            string userId = GetUserId();
            var inBasket = await _basketService.GetBasketAsync(userId);
            return View(inBasket);
        }

        public async Task<IActionResult> DeleteFromBasket(int id)
        {
            await _basketService.DeleteProductAsync(id);
            return Redirect("~/Shop/Basket");
        }

        public IActionResult IssueOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IssueOrder(string description)
        {
            string userId = GetUserId();
            await _orderService.AddOrdersAsymc(description, DateTime.Now, userId);
            return Redirect("~/Shop/Index");
        }

        public async Task<IActionResult> PurchaseHistory()
        {
            string userId = GetUserId();
            var data = await _orderService.GetOrdersAsync(userId);
            return View(data);
        }
    }
}
