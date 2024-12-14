using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBankApplication.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }        
        public string FromAccountName {  get; set; }        
        public string ToAccountName { get; set; }

        public Decimal FromAccountBal { get; set; }
        public Decimal ToAccountBal { get; set; }

        public Decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        [ForeignKey("FromAccountName")]
        public Account FromAccount{get; set; }

        [ForeignKey("ToAccountName")]
        public Account ToAccount { get; set; }

    }
}
