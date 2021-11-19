using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPoker.Backend
{
    public class VideoPokerManager
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public int Bet { get; set; } = 1;

        public void Hold(int[] cards)
        {

        }

        public void Deal()
        {
            for (int i = 0; i < 5; i++)
            {
                Cards.Add(new Card(GetRandomCardType(), GetRandomCardValue(), false));
            }
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
