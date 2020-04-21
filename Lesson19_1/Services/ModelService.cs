using AutoMapper;
using Lesson19_1.DataModels;
using Lesson19_1.Models;
using Lesson19_1.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Services
{
    public class ModelService : IModelService
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public ModelService(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddModelAsymc(CreateModelRequest model)
        {
            var data = new ModelData {Name = model.Name, BrandDataId = model.BrandDataId};

            await _dbContext.ModelData.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteModelAsync(int id)
        {
            _dbContext.ModelData.Remove(new ModelData { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public Task<ModelResponse> GetModelAsync(int id)
        {
            var model = _dbContext.ModelData.Include(b => b.BrandData).FirstOrDefault(b => b.Id == id);
            ModelResponse result = _mapper.Map<ModelResponse>(model);

            return Task.FromResult(result);
        }

        public async Task<IList<ModelResponse>> GetModelsAsync()
        {
            IList<ModelResponse> result = null;

            var models = await _dbContext.ModelData.Include(b => b.BrandData).ToListAsync(); 
            result = _mapper.Map<IList<ModelResponse>>(models);

            return result;
        }

        public async Task UpdateModelAsync(CreateModelRequest model)
        {
            _dbContext.ModelData.FirstOrDefault(m => m.Id == model.Id).Name = model.Name;
            _dbContext.ModelData.FirstOrDefault(m => m.Id == model.Id).BrandDataId = model.BrandDataId;
            await _dbContext.SaveChangesAsync();
        }
    }
}