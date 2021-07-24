using System;
using System.Text.RegularExpressions;
using LineBotAccountRecorder.Core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LineBotAccountRecorder.Service.CommandMessage
{
    public class CommandRegexFactory
    {
        private string commandPrefix = null;

        public CommandRegexFactory(
             IOptions<AppSettings> configuration)
        {
            this.commandPrefix = configuration.Value.LineBot.CommandPrefix;
        }

        public Regex CreatWithKeywordAndArgList(string commandKeyword, string[] commandArgList = null)
        {
            string regexString = @"(?<command>"+ Regex.Escape(this.commandPrefix) + Regex.Escape(commandKeyword) + @")";

            foreach (string commandArg in commandArgList)
            {
                regexString += @"\s(?<" + Regex.Escape(commandArg) + @">[^ ]*)";
            }

            Regex regex = new Regex(regexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return regex;
        }
    }
}
