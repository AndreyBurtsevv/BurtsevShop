using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson19_1.Models.Brand;
using Lesson19_1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lesson19_1.Controllers
{
    [Authorize]
    public class BrandWebController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandWebController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(CreateBrandRequest createBrand)
        {
            await _brandService.AddBrandAsymc(createBrand);

            return Redirect("~/BrandWeb/Index");
        }

        public async Task<IActionResult> Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
                var brands = await _brandService.GetBrandsAsync();
                return View(brands);
            //}
            //else
            //    return Redirect("~HomeController/Index");
        }

        public async Task<IActionResult> EditBrand(int id)
        {
            var data = await _brandService.GetBrandAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> EditBrand(CreateBrandRequest editBrand)
        {
            await _brandService.UpdateBrandAsync(editBrand);

            return Redirect("~/BrandWeb/Index");
        }

        public async Task<IActionResult> DeleteBrand(BrandResponse brand)
        {
            await _brandService.DeleteBrandAsync(brand.Id);

            return Redirect("~/BrandWeb/Index");
        }
    }
}
