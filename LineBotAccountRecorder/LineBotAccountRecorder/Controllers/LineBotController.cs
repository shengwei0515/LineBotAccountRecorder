using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using LineBotAccountRecorder.Service.LineBotWebhook;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LineBotAccountRecorder.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LineBotController : Controller
    {

        private readonly ILogger<LineBotController> logger = null;
        private readonly LineBotWebhookHandler lineBotWebhookHandler = null;

        public LineBotController(
            ILogger<LineBotController> logger,
            LineBotWebhookHandler lineBotWebhookHandler
            )
        {
            this.logger = logger;
            this.lineBotWebhookHandler = lineBotWebhookHandler;
        }

        [HttpGet]
        [Route("Chat")]
        public async Task<IActionResult> Get()
        {
            return this.Ok();
        }

        [HttpPost]
        [Route("Chat")]
        public async Task<IActionResult> Post([FromBody] JsonElement requestJson)
        {
            string channelAccessToken = Environment.GetEnvironmentVariable("LINE_BOT_CHANNEL_ACCESS_TOKEN");
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(channelAccessToken);

            try
            {
                isRock.LineBot.ReceivedMessage receivedMessage = isRock.LineBot.Utility.Parsing(requestJson.ToString());
                this.logger.LogInformation(requestJson.ToString());
                this.lineBotWebhookHandler.Process(receivedMessage);
                return this.Ok();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.ToString());
                return this.Ok();
            }
        }
    }
}
