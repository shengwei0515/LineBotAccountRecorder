using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace LineBotAccountRecorder.Service.CommandMessage
{
    public class CommandFilterAddAccountRecord : CommandMessageFilterBase
    {
        private readonly ILogger<CommandFilterAddAccountRecord> logger = null;
        public CommandFilterAddAccountRecord(
            ILogger<CommandFilterAddAccountRecord> logger,
            CommandRegexFactory regexFactory)
            : base(regexFactory)
        {
            this.logger = logger;
            base.SetupAtgList(new string[] { "amount", "debtor" });
        }

        public override void Filter(isRock.LineBot.ReceivedMessage receivedMessage)
        {
            this.logger.LogInformation("Filter Run");
            Match match = base.MatchMessage(receivedMessage);
            if (!match.Success)
            {
                this.logger.LogInformation(match.Value.ToString());
                return;
            }else
            {
                this.logger.LogInformation(match.Groups["debtor"].ToString());
                return;
            }
        }
    }
}
