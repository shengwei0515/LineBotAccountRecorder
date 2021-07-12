using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LineBotAccountRecorder.Dal.Models;
using LineBotAccountRecorder.Dal.UnitOfWork;
using LineBotAccountRecorder.Domain.AccountRecords;
using Microsoft.Extensions.Logging;

namespace LineBotAccountRecorder.Domain.Settle
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
            this.accountRecordService = accountRecordService;
        }


        public async Task<IEnumerable<DtoSettle>> TriggerSettle()
        {
            // get all unchecked account
            IEnumerable<AccountRecord> unckeckedRecords = await this.accountRecordService.FindByAccountStatus((int)EnumAccountRecordStatus.Unckecked);

            List<string> allUserList = unckeckedRecords.Select(x => x.Lender).Concat(unckeckedRecords.Select(x => x.Debtor)).Distinct().ToList();
            int totalUserCount = allUserList.Count();
            // in this metrix (i, j) means the number of money the ith user lend the jth user in allUserList
            int[,] debtMetrix = new int[totalUserCount, totalUserCount];

            foreach (AccountRecord record in unckeckedRecords)
            {
                int lenderIndex = allUserList.IndexOf(record.Lender);
                int debtorIndex = allUserList.IndexOf(record.Debtor);

                debtMetrix[lenderIndex, debtorIndex] += (int)record.Amount;
            }

            List<DtoSettle> dtoSettles = new List<DtoSettle>();

            for (int i = 0; i < allUserList.Count() - 1; i++)
            {
                for (int j = i + 1; j < allUserList.Count(); j++)
                {
                    DtoSettle settle = new DtoSettle();
                    // countervail lending and debt
                    int settleAmount = debtMetrix[i, j] - debtMetrix[j, i];

                    if (settleAmount == 0)
                    {
                        // Offset
                        continue;
                    }
                    else if (settleAmount > 0)
                    {
                        // positive -> lender is the lender
                        settle.Lender = allUserList[i];
                        settle.Debtor = allUserList[j];
                        settle.Amount = settleAmount;
                    }
                    else
                    {
                        // negative -> debtor is the lender
                        settle.Lender = allUserList[j];
                        settle.Debtor = allUserList[i];
                        settle.Amount = -1 * settleAmount;
                    }
                    Console.WriteLine(settle.Amount);
                    dtoSettles.Add(settle);
                }
            }
            return dtoSettles;
        }
    }
}
