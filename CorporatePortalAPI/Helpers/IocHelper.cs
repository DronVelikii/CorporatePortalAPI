using System.Collections.Generic;
using CorporatePortalAPI._3rdParty.System1;
using CorporatePortalAPI._3rdParty.System2;
using CorporatePortalAPI.Service;
using CorporatePortalAPI.Service.ServiceGates;
using Microsoft.Extensions.DependencyInjection;

namespace CorporatePortalAPI.Helpers
{
    public static class IocHelper
    {
        public static void InitServices(this IServiceCollection services)
        {
            services.AddSingleton<ISystem1, System1>();
            services.AddSingleton<ISystem2, System2>();
            services.AddSingleton<ServiceGate1>();
            services.AddSingleton<ServiceGate2>();

            // можно рефлексией бегать по сборке и автоматически находить всех наследников ServiceGate. Для простоты реализовано руками
            services.AddSingleton(x => new List<ServiceGate>
            {
                x.GetRequiredService<ServiceGate1>(),
                x.GetRequiredService<ServiceGate2>(),
            });

            services.AddSingleton<IService, Service.Service>();
        }
    }
}