using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Loger
{
    public class DbLogerProvider : ILoggerProvider
    {
        private readonly IApplicationBuilder _app;
        public DbLogerProvider(IApplicationBuilder app)
        {
            _app = app;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLoger(_app, categoryName);
        }

        public void Dispose()
        {
           
        }
    }
}
