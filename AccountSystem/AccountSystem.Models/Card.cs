using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Models
{
    public class Card
    {
        public int Id { get; set; }

        public CardType CardType { get; set; }

        [MinLength(16)]
        [MaxLength(16)]
        [Required]
        public string CardNumber { get; set; }

        [MinLength(4)]
        [MaxLength(6)]
        [Required]
        public string Pin { get; set; }        

        public DateTime? ExpirationDate { get; set; }

        public int AccountId { get; set; }

        public virtual BankAccount Account { get; set; }
    }
}
