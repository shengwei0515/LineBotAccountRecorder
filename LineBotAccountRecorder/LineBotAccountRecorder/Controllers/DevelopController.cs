using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LineBotAccountRecorder.Dal.Models;
using LineBotAccountRecorder.Domain.Settle;
using LineBotAccountRecorder.Domain.AccountRecords;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LineBotAccountRecorder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopController : Controller
    {
        private readonly ILogger<DevelopController> logger = null;
        private readonly AccountRecordService accountRecordService = null;
        private readonly SettleService settleService = null;

        public DevelopController(
            ILogger<DevelopController> logger,
            AccountRecordService accountRecordService,
            SettleService settleService)
        {
            this.logger = logger;
            this.accountRecordService = accountRecordService;
            this.settleService = settleService;
        }

        [HttpPost]
        [Route("AddAccountRecord")]
        public async Task<IActionResult> CreateAccountRecord([FromBody] AccountRecord accountRecord)
        {
            await this.accountRecordService.CreateAsync(accountRecord);
            return Ok();
        }

        [HttpGet]
        [Route("AccountRecord/Unckeck")]
        public async Task<IEnumerable<AccountRecord>> queryUnckeck()
        {
            return await this.accountRecordService.FindByAccountStatus((int)EnumAccountRecordStatus.Unckecked);
        }

        [HttpGet]
        [Route("Settle/uncheck")]
        public async Task<IEnumerable<DtoSettle>> settleUnckeckasync()
        {
            return await this.settleService.TriggerSettle();
        }
    }
}
