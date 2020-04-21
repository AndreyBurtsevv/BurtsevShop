using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Models.Model
{
    public class CreateModelRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandDataId { get; set; }
    }
}
