namespace AccountSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Account
    {
        private ICollection<Card> cards;

        public Account()
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

        public int OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public decimal Balance { get; set; }
    }
}
