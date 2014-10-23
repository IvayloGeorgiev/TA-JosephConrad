using System;

namespace AccountSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int? CardId { get; set; }

        public DateTime TimeOfTransaction { get; set; }

        public decimal Amount { get; set; }

        public string Reason { get; set; }

        public Guid? TargetIban { get; set; }

        public virtual BankAccount Account { get; set; }

        public virtual Card Card { get; set; }
    }
}
