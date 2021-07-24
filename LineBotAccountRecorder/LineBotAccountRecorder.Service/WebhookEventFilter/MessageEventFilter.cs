using System;
namespace LineBotAccountRecorder.Service.WebhookEventFilter
{
    public class MessageEventFilter : WebhookEventFilterBase
    {
        public MessageEventFilter(string eventType)
            :base(eventType)
        {
            ;
        }

        public override void Filter(isRock.LineBot.ReceivedMessage message)
        {
            if (!this.isPassed(message.events[0].type))
            {
                return;
            }
            else
            {
                /*
                 * CommandHandler.Run(message)
                 */
            }
        }
    }
}
