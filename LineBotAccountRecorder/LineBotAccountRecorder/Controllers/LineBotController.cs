using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using LineBotAccountRecorder.Service.CommandMessage;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LineBotAccountRecorder.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LineBotController : Controller
    {

        private readonly ILogger<LineBotController> logger = null;
        private readonly CommandMessageFilterBase commandFilter = null;

        public LineBotController(
            ILogger<LineBotController> logger,
            CommandMessageFilterBase commandFilter
            )
        {
            this.logger = logger;
            this.commandFilter = commandFilter;
        }

        [HttpGet]
        [Route("Chat")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Chat")]
        public async Task<IActionResult> Post([FromBody] JsonElement requestJson)
        {
            string channelAccessToken = Environment.GetEnvironmentVariable("LINE_BOT_CHANNEL_ACCESS_TOKEN");
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(channelAccessToken);

            try
            {
                //Console.WriteLine(requestJson);
                var receivedMessage = isRock.LineBot.Utility.Parsing(requestJson.ToString());
                var userMessage = "你說了: " + receivedMessage.events[0].message.text;
                var replyToken = receivedMessage.events[0].replyToken;
                this.commandFilter.SetupKeyword("測試");
                this.commandFilter.Filter(userMessage);

                return Ok();
            }
            catch(Exception ex)
            {
                logger.LogError(ex.ToString());
                return Ok();
            }
        }
    }
}
