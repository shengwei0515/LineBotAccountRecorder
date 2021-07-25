using Microsoft.Extensions.Logging;

namespace LineBotAccountRecorder.Service.CommandMessage
{
    public class CommandMessageHandler
    {
        private readonly ILogger<CommandMessageHandler> logger = null;
        private readonly CommandFilterAddAccountRecord addAccountRecordCommand = null;

        public CommandMessageHandler(
            ILogger<CommandMessageHandler> logger,
            CommandFilterAddAccountRecord addAccountRecordCommand
            )
        {
            this.logger = logger;
            this.addAccountRecordCommand = addAccountRecordCommand;
            this.addAccountRecordCommand.SetupKeyword("討債");
        }

        public void Process(isRock.LineBot.ReceivedMessage receivedMessage)
        {
            this.logger.LogInformation("Command Message Run");
            this.addAccountRecordCommand.Filter(receivedMessage);
        }
    }
}
