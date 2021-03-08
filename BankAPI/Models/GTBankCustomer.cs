using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models
{
    [Table("GTBankCustomer")]
    public class GTBankCustomer
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Column("AccountName")]
        [Display(Name = "Account Name")]
        [Required(ErrorMessage = "Account Name is required")]
        [StringLength(50, ErrorMessage = "AccountName Must Be less than 50 characters")]
        public string AccountName { get; set; }


        [Column("AccountNumber")]
        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "Account Number is required")]
        [StringLength(10, ErrorMessage = "AccountName Must Be less than 10 characters")]
        public string AccountNumber { get; set; }


        [Column("BankName")]
        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Bank Name is required")]
        [StringLength(50, ErrorMessage = "Bank Name Must Be less than 50 charactes")]

        public string BankName { get; set; }
    }
}
