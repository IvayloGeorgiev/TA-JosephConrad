using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Models
{
    public class Card
    {
        public int Id { get; set; }

        public CardType CardType { get; set; }

        public string Pin { get; set; }

        public virtual ApplicationUser Holder { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public virtual Account Account { get; set; }
    }
}
