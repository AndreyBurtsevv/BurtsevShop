using AutoMapper;
using Lesson19_1.DataModels;
using Lesson19_1.Helpers;
using Lesson19_1.Models;
using Lesson19_1.Models.Brand;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Services
{
    public class BrandService : IBrandService
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public BrandService(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddBrandAsymc(CreateBrandRequest brand)
        {
            var data = new BrandData { Name = brand.Name, Description = brand.Description };

            await _dbContext.BrandData.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public Task<BrandResponse> GetBrandAsync(int id)
        {
            var brand = _dbContext.BrandData.FirstOrDefault(b => b.Id == id);
            BrandResponse result = _mapper.Map<BrandResponse>(brand);

            return Task.FromResult(result);
        }

        public async Task<IList<BrandResponse>> GetBrandsAsync()
        {
            var brands = await _dbContext.BrandData.ToListAsync();
            IList<BrandResponse> result = _mapper.Map<IList<BrandResponse>>(brands);
            return result;
        }

        public async Task UpdateBrandAsync(CreateBrandRequest brand)
        {
            _dbContext.BrandData.First(x => x.Id == brand.Id).Name = brand.Name;
            _dbContext.BrandData.First(x => x.Id == brand.Id).Description = brand.Description;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBrandAsync(int id)
        {
            _dbContext.BrandData.Remove(new BrandData { Id = id });
            await _dbContext.SaveChangesAsync();

        }
    }
}
