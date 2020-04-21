using Lesson19_1.Models;
using Lesson19_1.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Services
{
    public interface IModelService
    {
        Task<IList<ModelResponse>> GetModelsAsync();

        Task AddModelAsymc(CreateModelRequest model);
        Task<ModelResponse> GetModelAsync(int id);
        Task DeleteModelAsync(int id);
        Task UpdateModelAsync(CreateModelRequest model);
    }
}
