using OnlineBankApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBankApplication.Dto
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
       
        public string FromAccountName { get; set; }

        public string ToAccountName { get; set; }

        public Decimal FromAccountBal { get;  set; }
        public Decimal ToAccountBal { get;  set; }
        [Required]
        [Range(0, int.MaxValue)]
        public Decimal Amount { get; set; }
       
        public DateTime TransactionDate { get; set; }       

    }
}
