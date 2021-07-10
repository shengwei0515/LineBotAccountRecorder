using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LineBotAccountRecorder.Dal.Models
{
    [Table("AccountRecords")]
    public class DaoAccountRecord
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Lender { get; set; }

        [Required]
        public string? Debtor { get; set; }

        [Required]
        public int? Amount { get; set; }

        [Required]
        public int? AccountRecordStatus { get; set; }
    }
}
