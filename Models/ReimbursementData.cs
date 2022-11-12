using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class ReimbursementData
    {
        [Key]
        public int ReimbursementID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string ReimbursementType { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string RequestedBy { get; set; }
        public int RequestedValue { get; set; }
        public int ApprovedValue { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ApprovedBy { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string Currency { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string ReceiptAttached { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ReceiptImageLink { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string RequestedPhase { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string InternalNotes{get;set;}
    }
}
