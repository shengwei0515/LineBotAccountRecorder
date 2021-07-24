using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace LineBotAccountRecorder.Service.CommandMessage
{
    public class CommandMessageFilterBase
    {
        private readonly ILogger<CommandMessageFilterBase> logger = null;
        private readonly CommandRegexFactory regexFactory = null;
        private readonly String[] commandArgList = new string[] { };
        private Regex commandRegex = null;

        public CommandMessageFilterBase(
            ILogger<CommandMessageFilterBase> logger,
            CommandRegexFactory regexFactory)
        {
            this.logger = logger;
            this.regexFactory = regexFactory;
        }

        public void SetupKeyword(string commandKeyword)
        {
            this.commandRegex = this.regexFactory.CreatWithKeywordAndArgList(commandKeyword, this.commandArgList);
        }

        protected Match MatchMessage(string message)
        {
            return this.commandRegex.Match(message);
        }


        public void Filter(string message)
        {
            Match match = this.MatchMessage(message);
            if (!match.Success)
            {
                this.logger.LogInformation("Message Match Note Match");
                return;
            }
            else
            {
                this.logger.LogInformation("Message Match Suyccess");
                return;
            }
        }
    }
}
