using System;
using System.Collections.Generic;
using VideoPoker.Backend.Cards;

namespace VideoPoker.Backend
{
    public class VideoPokerManager
    {
        public int Bet { get; set; } = 1;

        public void Hold(int[] cards)
        {

        }

        public List<Card> Deal()
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < 5; i++)
            {
                cards.Add(new Card(GetRandomCardType(), GetRandomCardValue(), false));
            }

            for (int i = 0; i < cards.Count; i++)
            {
                for (int j = cards.Count - 1; j <= 0; j--)
                {
                    if (cards[i].CardValue == cards[j].CardValue && cards[i].CardType == cards[j].CardType)
                    {
                        return Deal();
                    }
                }
            }

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
