using CalculateInterest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CalculateInterestTest
{
    [TestClass]
    public class UnitTest1
    {
        public Card CardVisa;
        public Card CardMC;
        public Card CardDiscover;

        [TestInitialize]
        public void TestInitialize()
        {
            CardVisa = new Card
            {
                CardType = Card.TypeOfCard.VISA,
                InterestPercentage = 10,
                Balance = 100
            };

            CardMC = new Card
            {
                CardType = Card.TypeOfCard.MC,
                InterestPercentage = 5,
                Balance = 100
            };

            CardDiscover = new Card
            {
                CardType = Card.TypeOfCard.DISCOVER,
                InterestPercentage = 1,
                Balance = 100
            };
        }

        /// <summary>
        /// 1 person has 1 wallet and 3 cards (1 Visa, 1 MC, 1 Discover) – Each Card has a balance of $100
        /// Calculate the total interest (simple interest) for this person and per card
        /// </summary>
        [TestMethod]
        public void TestCase1()
        {
            // arrange
            var WalletA = new Wallet
            {
                Cards = new List<Card>
                {
                    CardVisa,
                    CardMC,
                    CardDiscover
                }
            };

            var PersonA = new Person
            {
                Wallets = new List<Wallet>
                {
                    WalletA
                }
            };

            //act
            var TotalInterest = PersonA.CalculateInterest();

            //assert
            Assert.AreEqual(TotalInterest, 16);
        }

        /// <summary>
        /// 1 person has 2 wallets Wallet 1 has a Visa and Discover , wallet 2 a MC - each card has $100 balance
        /// Calculate the total interest(simple interest) for this person and interest per wallet
        /// </summary>
        [TestMethod]
        public void TestCase2()
        {
            // arrange
            var WalletA = new Wallet
            {
                Cards = new List<Card>
                {
                    CardVisa,
                    CardDiscover
                }
            };

            var WalletB = new Wallet
            {
                Cards = new List<Card>
                {
                    CardMC
                }
            };

            var PersonA = new Person
            {
                Wallets = new List<Wallet>
                {
                    WalletA,
                    WalletB
                }
            };

            //act
            var TotalInterest = PersonA.CalculateInterest();

            //assert
            Assert.AreEqual(TotalInterest, 16);
            Assert.AreEqual(PersonA.Wallets[0].WalletInterest, 11);
            Assert.AreEqual(PersonA.Wallets[1].WalletInterest, 5);
        }

        /// <summary>
        /// 2 people have 1 wallet each,
        /// person 1 has 1 wallet with 3 cards (1 MC, 1 Visa, 1 Discover),
        /// person 2 has 1 wallet with 2 cards (1 Visa, 1 MC) all cards in all wallets for both people have a $100 balance
        /// Calculate the total interest(simple interest) for each person and interest per wallet
        /// </summary>
        [TestMethod]
        public void TestCase3()
        {
            var WalletA = new Wallet
            {
                Cards = new List<Card>
                {
                    CardMC,
                    CardVisa,
                    CardDiscover
                }
            };

            var PersonA = new Person
            {
                Wallets = new List<Wallet>
                {
                    WalletA
                }
            };

            var WalletB = new Wallet
            {
                Cards = new List<Card>
                {
                    CardVisa,
                    CardMC
                }
            };

            var PersonB = new Person
            {
                Wallets = new List<Wallet>
                {
                    WalletB
                }
            };


            //act
            var TotalInterestA = PersonA.CalculateInterest();
            var TotalInterestB = PersonB.CalculateInterest();

            //assert
            Assert.AreEqual(TotalInterestA, 16);
            Assert.AreEqual(TotalInterestB, 15);
            Assert.AreEqual(PersonA.Wallets[0].WalletInterest, 16);
            Assert.AreEqual(PersonB.Wallets[0].WalletInterest, 15);
        }
    }
}

