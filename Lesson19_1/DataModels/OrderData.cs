using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.DataModels
{
    public class OrderData
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string ModelName { get; set; }

        public string BrandName { get; set; }

        public string Description { get; set; }
    }
}
