using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.DataModels
{
    public class ModelData
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandDataId { get; set; }

        public BrandData BrandData { get; set; }
    }
}
