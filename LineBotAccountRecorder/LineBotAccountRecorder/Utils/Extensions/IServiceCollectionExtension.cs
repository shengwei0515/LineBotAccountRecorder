using System;
using LineBotAccountRecorder.Service.CommandMessage;
using LineBotAccountRecorder.Dal.UnitOfWork;
using LineBotAccountRecorder.Domain.AccountRecords;
using LineBotAccountRecorder.Domain.Settle;
using Microsoft.Extensions.DependencyInjection;
using LineBotAccountRecorder.Core.Models;

namespace LineBotAccountRecorder.Utils.Extensions
{
    public static class IServiceCollectionExtension
    {

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            services.AddSingleton<CommandRegexFactory, CommandRegexFactory>();
            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<SettleService, SettleService>();
            services.AddScoped<AccountRecordService, AccountRecordService>();
            return services;
        }
    }
}
