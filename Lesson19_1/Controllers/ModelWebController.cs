using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson19_1.Models.Model;
using Lesson19_1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson19_1.Controllers
{
    [Authorize]
    public class ModelWebController : Controller
    {
        private readonly IModelService _modelService;

        public ModelWebController(IModelService modelService)
        {
            _modelService = modelService;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _modelService.GetModelsAsync();
            return View(models);
        }

        public async Task<IActionResult> ModelEdit(int id)
        {
            var data = await _modelService.GetModelAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> ModelEdit(CreateModelRequest editModel)
        {
            await _modelService.UpdateModelAsync(editModel);
            return Redirect("~/ModelWeb/Index");
        }

        public IActionResult AddModel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddModel(CreateModelRequest createModel)
        {
            await _modelService.AddModelAsymc(createModel);

            return Redirect("~/ModelWeb/Index");
        }

        public async Task<IActionResult> ModelDelete(ModelResponse model)
        {
            await _modelService.DeleteModelAsync(model.Id);

            return Redirect("~/ModelWeb/Index");
        }
    }
}
