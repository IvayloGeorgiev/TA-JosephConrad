namespace AccountSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BankAccount
    {
        private ICollection<Card> cards;

        public BankAccount()
        {
            this.IBAN = Guid.NewGuid();
            this.cards = new HashSet<Card>();
        }

        public CurrencyType CurrencyType { get; set; }

        public virtual ICollection<Card> Cards
        {
            get { return this.cards; }
            set { this.cards = value; }
        }

        public Guid IBAN { get; set; }

        public int Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public decimal Balance { get; set; }
    }
}
