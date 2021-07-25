using System;
using isRock.LineBot;
using Microsoft.Extensions.Logging;

namespace LineBotAccountRecorder.Service.WebhookEventFilter
{
    public abstract class WebhookEventFilterBase
    {

        protected readonly string eventType = null;

        public WebhookEventFilterBase(string eventType)
        {
            this.eventType = eventType;
        }

        protected bool isPassed(string eventTypeFromRequest)
        {
            return this.eventType == eventTypeFromRequest;
        }

        // override this function for all different type message
        public virtual void Filter(isRock.LineBot.ReceivedMessage message)
        {
            if (!this.isPassed(message.events[0].type))
            {
                return;
            }
            else
            {
                Console.WriteLine("Pass through filter");
            }
        }
    }
}
