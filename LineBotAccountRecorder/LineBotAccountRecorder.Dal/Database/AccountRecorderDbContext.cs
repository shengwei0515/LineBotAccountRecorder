using System;
using LineBotAccountRecorder.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace LineBotAccountRecorder.Dal.Database
{
    public class AccountRecorderDbContext : DbContext
    {
        private readonly DbContextOptions options = null;

        public AccountRecorderDbContext(DbContextOptions options)
            : base(options)
        {
            this.options = options;
        }

        /// <summary>
        /// Member
        /// </summary>
        public DbSet<AccountRecord> Member { get; set; }
    }
}
