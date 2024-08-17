using CurrencyConverter.Application.Shared.Helpers;
using CurrencyConverter.Application.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ReceiptManagment.Application.Receipt.Interfaces;
using ReceiptManagment.Application.Receipt;

namespace CurrencyConverter.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

           
            services.AddScoped<IDateTimeService, DateTimeService>();
            services.AddScoped<IITemService, ItemService>();
            services.AddScoped<IReceiptService, ReceiptServices>();



            return services;
        }
    }
}
