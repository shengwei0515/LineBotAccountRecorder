using System;
namespace LineBotAccountRecorder.Core.Models.DTO
{
    public class DtoDebt
    {
        public string? Lender { get; set; }
        public string? Debtor { get; set; }
        public int? Amount { get; set; }
        public int? AmountStatus { get; set; }
    }
}
