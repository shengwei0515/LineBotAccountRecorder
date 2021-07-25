using System;
using LineBotAccountRecorder.Service.CommandMessage;
using LineBotAccountRecorder.Service.LineBotWebhook;
using LineBotAccountRecorder.Service.WebhookEventFilter;
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
            // LineBotWebhook
            services.AddScoped<LineBotWebhookHandler, LineBotWebhookHandler>();

            // WebhookEventFilter
            services.AddScoped<MessageEventFilter, MessageEventFilter>();

            // CommandMessage
            services.AddScoped<CommandMessageHandler, CommandMessageHandler>();
            services.AddScoped<CommandRegexFactory, CommandRegexFactory>();
            services.AddScoped<CommandFilterAddAccountRecord, CommandFilterAddAccountRecord>();
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
