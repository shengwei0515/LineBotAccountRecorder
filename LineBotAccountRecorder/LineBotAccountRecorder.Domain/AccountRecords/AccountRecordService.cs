using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LineBotAccountRecorder.Core.Utils.Specification;
using LineBotAccountRecorder.Dal.Models;
using LineBotAccountRecorder.Dal.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace LineBotAccountRecorder.Domain.AccountRecords
{
    public class AccountRecordService
    {
        private readonly ILogger<AccountRecordService> logger = null;
        private readonly IUnitOfWork uow = null;


        public AccountRecordService(
            ILogger<AccountRecordService> logger,
            IUnitOfWork uow)
        {
            this.logger = logger;
            this.uow = uow;
        }

        public async Task CreateAsync(AccountRecord accountRecord)
        {

            this.uow.Repository<AccountRecord>().Create(accountRecord);
            this.uow.Commit();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<AccountRecord>> FindByAccountStatus(int status)
        {
            ISpecification<AccountRecord> specAccountRecord = new SpecAccountRecordStatus(status);

            var recordEntities = this.uow.Repository<AccountRecord>().Find(specAccountRecord);

            return recordEntities;
        }
    }
}
