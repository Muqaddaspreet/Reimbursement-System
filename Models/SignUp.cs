using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class SignUp
    {
        [Key]
        public int SignUpID { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [Required(ErrorMessage = "This Field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "This Field is required")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        //[StringLength(20, MinimumLength = 10, ErrorMessage = "PAN Number lenght atleast 10 character")]
        [Required(ErrorMessage = "This Field is required")]
        public string PanNumber { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "This Field is required")]
        public string Bank { get; set; }
        //[StringLength(20, MinimumLength = 12, ErrorMessage = "Account Number length must be 12 character")]
        [Column(TypeName = "nvarchar(12)")]
        [Required(ErrorMessage = "This Field is required")]
        public string BankAccountNumber { get; set; }
        public int IsApprover { get; set; }
    }
}
