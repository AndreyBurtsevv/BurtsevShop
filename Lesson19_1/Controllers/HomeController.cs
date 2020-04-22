using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson19_1.Models.Brand;
using Lesson19_1.Models.Model;
using Lesson19_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson19_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrandService _brandService;

        private readonly IModelService _modelService;
        
        public HomeController(IBrandService brandService, IModelService modelService)
        {
            _brandService = brandService;
            _modelService = modelService;
        }
        public async Task<IActionResult> Index()
        {
            var brands = await _brandService.GetBrandsAsync();
            return View(brands);
        }

        public async Task<IActionResult> Models()
        {
            var models = await _modelService.GetModelsAsync();
            return View(models);
        }

        public async Task<IActionResult> ModelEdit(int id)
        {
            var data = await _modelService.GetModelAsync(id);

            return View(data);
        }

        public IActionResult AddModel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddModel(CreateModelRequest createModel)
        {
            await _modelService.AddModelAsymc(createModel);

            return Redirect("~/Home");
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}