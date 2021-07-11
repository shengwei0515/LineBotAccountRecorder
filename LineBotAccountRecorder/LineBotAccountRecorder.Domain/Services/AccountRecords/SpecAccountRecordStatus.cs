using System;
using System.Linq.Expressions;
using LineBotAccountRecorder.Core.Utils.Specification;
using LineBotAccountRecorder.Dal.Models;

namespace LineBotAccountRecorder.Domain.Services.AccountRecords
{
    public class SpecAccountRecordStatus : SpecificationBase<AccountRecord>
    {
        private readonly int status = -1;

        public SpecAccountRecordStatus(int status)
        {
            this.status = status;
        }

        public override Expression<Func<AccountRecord, bool>> SpecExpression
        {
            get
            {
                return accountRecord => accountRecord.AccountRecordStatus == this.status;
            }
        }
    }
}
