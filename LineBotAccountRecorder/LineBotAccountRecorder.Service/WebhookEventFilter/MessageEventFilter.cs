using System;
using LineBotAccountRecorder.Core.Models;
using LineBotAccountRecorder.Service.CommandMessage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LineBotAccountRecorder.Service.WebhookEventFilter
{
    public class MessageEventFilter : WebhookEventFilterBase
    {
        private readonly ILogger<MessageEventFilter> logger = null;
        private readonly String commandPrefix = null;
        private readonly CommandMessageHandler commandMessageHandler = null;

        public MessageEventFilter(
            ILogger<MessageEventFilter> logger,
            IOptions<AppSettings> configurations,
            CommandMessageHandler commandMessageHandler)
            : base("message")
        {
            this.logger = logger;
            this.commandPrefix = configurations.Value.LineBot.CommandPrefix;
            this.commandMessageHandler = commandMessageHandler;
        }

        public override void Filter(isRock.LineBot.ReceivedMessage receivedMessage)
        {
            if (!this.isPassed(receivedMessage.events[0].type))
            {
                return;
            }
            else
            {
                this.logger.LogInformation("Accept Message Event");
                // message start with commandPrefix, trigger commandMessageHandler
                string firstLetterOfMessage = receivedMessage.events[0].message.text[0].ToString();
                if (firstLetterOfMessage == this.commandPrefix)
                {
                    this.commandMessageHandler.Process(receivedMessage);
                }
            }
        }
    }
}
