using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.DataModels
{
    public class BasketData
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public UserData UserData { get; set; }

        public string Description { get; set; }
 
        public int ModelDataId { get; set; }

        public ModelData ModelData { get; set; }
    }
}
