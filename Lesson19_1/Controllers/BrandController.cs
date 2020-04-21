using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson19_1.Models;
using Lesson19_1.Models.Brand;
using Lesson19_1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lesson19_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private IBrandService _brandService;
        private ILogger<BrandController> logger;
        public BrandController(IBrandService brandService, ILogger<BrandController> log)
        {
            _brandService = brandService;
            logger = log;
        }

        [HttpGet]
        public async Task<IEnumerable<BrandResponse>> Get()
        {
            logger.LogInformation("Requested GET");
            return await _brandService.GetBrandsAsync();
        }

        //baseurl/brand/id
        [HttpGet("{id}")]
        public async Task<ServerResponse<BrandResponse>> Get(int id)
        {
            BrandResponse brand = await _brandService.GetBrandAsync(id);
            if (brand == null)
            {
                return new ServerResponse<BrandResponse> { IsSuccess = false, Error = $"Brand not found with id={id}" };
            }
            return new ServerResponse<BrandResponse> { IsSuccess = true, Result = brand };
        }


        [HttpPost]
        public async Task Post(CreateBrandRequest brand)
        {
            logger.LogInformation("Requested POST"); 
            await _brandService.AddBrandAsymc(brand);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            logger.LogInformation("Requested DELETE");
            await _brandService.DeleteBrandAsync(id);
        }

        [HttpPut]
        public async Task Put(CreateBrandRequest brand)
        {
            logger.LogInformation("Requested PUT");
            await _brandService.UpdateBrandAsync(brand);
        }
    }
}
