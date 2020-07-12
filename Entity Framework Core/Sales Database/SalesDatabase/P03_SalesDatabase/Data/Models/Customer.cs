namespace P03_SalesDatabase.Data.Models
{
    using P03_SalesDatabase.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }

        [Required, MaxLength(GlobalConstants.CustomerNameMaxLength)]
        public string Name { get; set; }

        [Required, MaxLength(GlobalConstants.EmailMaxLength)]
        public string Email { get; set; }

        [Required, StringLength(GlobalConstants.CreditCardLength)]
        public string CreditCardNumber { get; set; }

        [Required]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
