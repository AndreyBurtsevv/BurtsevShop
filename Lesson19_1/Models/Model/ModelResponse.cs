using Lesson19_1.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Models.Model
{
    public class ModelResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BrandResponse BrandData { get; set; }
    }
}
 