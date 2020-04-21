﻿using Lesson19_1.DataModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Loger
{
    public class DbLoger : ILogger
    {
        private readonly IApplicationBuilder _app;
        private string _category;

        public DbLoger(IApplicationBuilder app, string category)
        {
            _app = app;
            _category = category;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true; 
        }

        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var log = new LogData { Category = _category, Message = state.ToString() };

            using (var serviceScope = _app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MyDbContext>();
                await context.LogData.AddAsync(log);
                await context.SaveChangesAsync();
            }
        }
    }
}
