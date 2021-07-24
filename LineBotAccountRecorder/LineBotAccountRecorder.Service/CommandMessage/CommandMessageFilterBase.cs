using System;
namespace LineBotAccountRecorder.Service.CommandMessage
{
    public abstract class CommandMessageFilterBase
    {
        private string commandRegexString;

        public CommandMessageFilterBase(string commandRegexString)
        {
            this.commandRegexString = commandRegexString;
        }

        

        public virtual void Filter(string message)
        {

        }
    }
}
