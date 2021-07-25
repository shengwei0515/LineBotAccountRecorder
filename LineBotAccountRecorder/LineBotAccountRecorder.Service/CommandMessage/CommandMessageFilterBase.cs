using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace LineBotAccountRecorder.Service.CommandMessage
{
    public abstract class CommandMessageFilterBase
    {
        private readonly CommandRegexFactory regexFactory = null;
        private String[] commandArgList = new string[] { };
        private Regex commandRegex = null;

        public CommandMessageFilterBase(
            CommandRegexFactory regexFactory)
        {
            this.regexFactory = regexFactory;
        }

        protected void SetupAtgList(string[] argList)
        {
            this.commandArgList = argList;
        }

        public void SetupKeyword(string commandKeyword)
        {
            this.commandRegex = this.regexFactory.CreatWithKeywordAndArgList(commandKeyword, this.commandArgList);
        }

        protected Match MatchMessage(isRock.LineBot.ReceivedMessage receivedMessage)
        {
            string message = receivedMessage.events[0].message.text;
            return this.commandRegex.Match(message);
        }

        virtual public void Filter(isRock.LineBot.ReceivedMessage receivedMessage)
        {
            Match match = this.MatchMessage(receivedMessage);
            if (!match.Success)
            {
                Console.WriteLine("Message Match Note Match");
                return;
            }
            else
            {
                Console.WriteLine("Message Match Suyccess");
                return;
            }
        }
    }
}
