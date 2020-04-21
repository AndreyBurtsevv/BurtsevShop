using Lesson19_1.Models;
using Lesson19_1.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Services
{
    public interface IBrandService
    {
        Task<IList<BrandResponse>> GetBrandsAsync();

        Task<BrandResponse> GetBrandAsync(int id);

        Task AddBrandAsymc(CreateBrandRequest brand);
        Task DeleteBrandAsync(int id);
        Task UpdateBrandAsync(CreateBrandRequest brand);
    }
}
