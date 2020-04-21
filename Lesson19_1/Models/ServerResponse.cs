using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Models
{
    public class ServerResponse<T>
    {
        public T Result { get; set; }

        public bool IsSuccess { get; set; }

        public string Error { get; set; }

        public int ErrorCode { get; set; }
    }
}
