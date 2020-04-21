using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson19_1.Models;
using Lesson19_1.Models.Model;
using Lesson19_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson19_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        IModelService _modelService = null;

        public ModelController(IModelService model)
        {
            _modelService = model;
        }

        [HttpGet]
        public async Task<IEnumerable<ModelResponse>> Get()
        {
            return await _modelService.GetModelsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServerResponse<ModelResponse>> Get(int id)
        {
            ModelResponse model = await _modelService.GetModelAsync(id);
            if (model == null)
            {
                return new ServerResponse<ModelResponse> { IsSuccess = false, Error = $"Model not found with id={id}" };
            }
            return new ServerResponse<ModelResponse> { IsSuccess = true, Result = model };
        }

        [HttpPost]
        public async Task Post(CreateModelRequest model)
        {
            await _modelService.AddModelAsymc(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _modelService.DeleteModelAsync(id);
        }

        [HttpPut]
        public async Task Put(CreateModelRequest model)
        {
            await _modelService.UpdateModelAsync(model);
        }
    }
}