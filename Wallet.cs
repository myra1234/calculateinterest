using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateInterest.Models
{
    public class Wallet
    {
        public List<Card> Cards { get; set; }

        public double WalletInterest { get; set; }
    }
}
