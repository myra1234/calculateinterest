using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateInterest.Models
{
    public class Card
    {
        public enum TypeOfCard
        {
            VISA,
            MC,
            DISCOVER
        }

        public TypeOfCard CardType { get; set; }

        public double InterestPercentage { get; set; }

        public double Balance { get; set; }

        public double Interest { get; set; }
    }
}
