using System;
using System.Collections.Generic;
using VideoPoker.Backend.Cards;

namespace VideoPoker.Backend
{
    public class VideoPokerManager
    {
        public int Bet { get; set; } = 1;
        public bool[] CardsHold { get; set; } = new bool[5];

        private Card[] _cards = new Card[5];

        public Card[] Deal()
        {
            Card[] cards = new Card[5];

            for (int i = 0; i < 5; i++)
            {
                if (CardsHold[i])
                {
                    cards[i] = _cards[i];
                }
                else
                {
                    cards[0] = new Card(GetRandomCardType(), GetRandomCardValue(), false);
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

            _cards = cards;
            return cards;
        }

        public CardValue GetRandomCardValue()
        {
            Random random = new Random();
            var randomInt = random.Next(0, 8);
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
