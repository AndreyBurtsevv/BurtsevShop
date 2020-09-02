using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Models.Basket
{
    public class CreateBasket
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Decriprion { get; set; }

        public int ModelDataId { get; set; }
    }
}
