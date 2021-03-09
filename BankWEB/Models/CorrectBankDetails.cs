using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankWEB.Models
{
    public class CorrectBankDetails
    {
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
        [Display(Name = "Account Holders Name")]
        public string AccountName { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Is Account Valid?")]
        public bool? IsValidAccount { get; set; }
    }
}
