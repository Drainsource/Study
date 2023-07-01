using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DIDemoLib
{
    public static class DependencyInjection
    {
        public static IServiceCollection DIDemoLib(this IServiceCollection services)
        {
            services.AddTransient<IMessages, Messages>();
            return services;
        }
    }
}
