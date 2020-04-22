using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Models.Order
{
    public class OrderResponse
    {
        public DateTime Date { get; set; }

        public string ModelName { get; set; }

        public string BrandName { get; set; }

        public string Description { get; set; }
    }
}
