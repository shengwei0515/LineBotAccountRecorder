using System;
using LineBotAccountRecorder.Dal.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace LineBotAccountRecorder.Utils.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
