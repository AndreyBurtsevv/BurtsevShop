﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.DataModels
{
    public class LogData
    {
        [Key] 
        public int Id { get; set; }

        public string Category { get; set; }

        public string Message { get; set; }
    }
}
