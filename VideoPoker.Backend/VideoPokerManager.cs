using System;
using VideoPoker.Backend.Cards;

namespace VideoPoker.Backend
{
    public class VideoPokerManager
    {
        public int Credits { get; set; } = 100;
        public int Bet { get; set; } = 1;
        public bool[] CardsHold { get; set; } = new bool[5];

        private Card[] _cards = new Card[5];

        public Card[] Deal()
        {
            Credits = Credits - Bet;

            Card[] cards = new Card[5];

            for (int i = 0; i < 5; i++)
            {
                if (CardsHold[i])
                {
                    cards[i] = _cards[i];
                }
                else
                {
                    cards[i] = new Card(GetRandomCardType(), GetRandomCardValue());
                }
            }

            for (int i = 0; i < cards.Length; i++)
            {
                for (int j = cards.Length - 1; j <= 0; j--)
                {
                    if (cards[i].CardValue == cards[j].CardValue && cards[i].CardType == cards[j].CardType)
                    {
                        return Deal();
                    }
                }
            }

            WinChecker winChecker = new WinChecker();
            Credits += winChecker.CheckWin(cards, Bet);

            _cards = cards;
            return cards;
        }

        public CardValue GetRandomCardValue()
        {
            Random random = new Random();
            var randomInt = random.Next(7, 15);
            return (CardValue)randomInt;
        }

        public CardType GetRandomCardType()
        {
            Random random = new Random();
            var randomInt = random.Next(0, 4);
            return (CardType)randomInt;
        }
    }
}
