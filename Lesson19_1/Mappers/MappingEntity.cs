using AutoMapper;
using Lesson19_1.DataModels;
using Lesson19_1.Models;
using Lesson19_1.Models.Basket;
using Lesson19_1.Models.Brand;
using Lesson19_1.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Mappers
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<BrandData, BrandResponse>();
            CreateMap<ModelData, ModelResponse>();
            CreateMap<BasketData, BasketResponse>();
        }

    }
}
