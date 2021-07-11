using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LineBotAccountRecorder.Core.Utils.Specification;
using LineBotAccountRecorder.Dal.Models;
using LineBotAccountRecorder.Dal.UnitOfWork;
using LineBotAccountRecorder.Domain.Services.AccountRecords;
using Microsoft.Extensions.Logging;

namespace LineBotAccountRecorder.Domain.Services.Settle
{
    public class SettleService
    {
        private readonly ILogger<SettleService> logger = null;
        private readonly IUnitOfWork uow = null;
        private readonly AccountRecordService accountRecordService = null;

        public SettleService(
            ILogger<SettleService> logger,
            IUnitOfWork uow,
            AccountRecordService accountRecordService)
        {
            this.logger = logger;
            this.uow = uow;
        }

        
        //public async Task<IEnumerable<DtoSettle>> TriggerSettle()
        //{
        //    // get all unchecked account
        //    IEnumerable<AccountRecord> unckeckedRecords = await this.accountRecordService.FindByAccountStatus((int)EnumAccountRecordStatus.Unckecked);

        //    List<string> allUserList = unckeckedRecords.Select(x => x.Lender).Concat(unckeckedRecords.Select(x => x.Debtor)).Distinct().ToList();
        //    int totalUserCount = allUserList.Count();
        //    // in this metrix (i, j) means the number of money the ith user lend the jth user in allUserList
        //    int[,] debtMetrix = new int[totalUserCount, totalUserCount];

        //    foreach (AccountRecord record in unckeckedRecords)
        //    {
        //        int lenderIndex = allUserList.IndexOf(record.Lender);
        //        int debtorIndex = allUserList.IndexOf(record.Debtor);

        //        debtMetrix[lenderIndex, debtorIndex] += (int)record.Amount;
        //    }



        //}
    }
}
