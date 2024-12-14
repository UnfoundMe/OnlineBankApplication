using System.ComponentModel.DataAnnotations;

namespace OnlineBankApplication.Models
{
    public class Account
    {
        [Key]
        public string AccountName { get; set; }

        public Decimal? Balance { get; set; }

    }
}
