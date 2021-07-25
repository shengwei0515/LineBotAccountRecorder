using LineBotAccountRecorder.Service.WebhookEventFilter;
using Microsoft.Extensions.Logging;

namespace LineBotAccountRecorder.Service.LineBotWebhook
{
    public class LineBotWebhookHandler
    {
        private readonly ILogger<LineBotWebhookHandler> logger = null;
        private readonly MessageEventFilter messageEventFilter = null;

        public LineBotWebhookHandler(
            ILogger<LineBotWebhookHandler> logger,
            MessageEventFilter messageEventFilter)
        {
            this.logger = logger;
            this.messageEventFilter = messageEventFilter;
        }

        public void Process(isRock.LineBot.ReceivedMessage receivedMessage)
        {
            if (receivedMessage.events.Count == 0)
            {
                this.logger.LogInformation("Received Message Without Event");
            }
            else
            {
                this.messageEventFilter.Filter(receivedMessage);
            }
        }
    }
}
