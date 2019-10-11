using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateInterest.Models
{
    public class Person
    {
        public List<Wallet> Wallets { get; set; }
       
        public double CalculateInterest()
        {
            double ti = 0.0;

            foreach (var w in Wallets)
            {
                foreach (var c in w.Cards)
                {
                    c.Interest = (c.InterestPercentage * c.Balance) / 100;

                    w.WalletInterest += c.Interest;
                    ti += c.Interest;
                }
            }

            return ti;
        }
    }
}
