using Lesson19_1.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Models.Basket
{
    public class BasketResponse
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ModelResponse ModelData { get; set; }
    }
}
