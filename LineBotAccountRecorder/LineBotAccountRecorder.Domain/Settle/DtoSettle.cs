using System;
using System.ComponentModel.DataAnnotations;

namespace LineBotAccountRecorder.Domain.Settle
{
    public class DtoSettle
    {
        [Required]
        public string Lender { get; set; }

        [Required]
        public string Debtor { get; set; }

        [Required]
        public int? Amount { get; set; }
    }
}
