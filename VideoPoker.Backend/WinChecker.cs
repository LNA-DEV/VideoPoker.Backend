using System;
using System.Collections.Generic;
using System.Linq;
using VideoPoker.Backend.Cards;

namespace VideoPoker.Backend
{
    public class WinChecker
    {
        public int CheckWin(Card[] cards, int bet)
        {
            int score = 0;

            List<Card> cardsList = new List<Card>();
            foreach (var item in cards)
            {
                cardsList.Add(item);
            }
            cardsList.Sort();


            if (CheckJacksOrBetter(cardsList))
            {
                score = bet;
            }

            if (Check3ofAKind(cardsList))
            {
                score = bet * 3;
            }

            if (CheckStraight(cardsList))
            {
                score = bet * 4;
            }

            if (CheckFlush(cardsList))
            {
                score = bet * 6;
            }

            if (CheckFullHouse(cardsList))
            {
                score = bet * 9;
            }

            if (Check4ofAKind(cardsList))
            {
                score = bet * 25;
            }

            if (CheckStraightFlush(cardsList))
            {
                score = bet * 50;
            }

            if (CheckRoyalFlush(cardsList))
            {
                switch (bet)
                {
                    case 1:
                        score = 250;
                        break;
                    case 2:
                        score = 500;
                        break;
                    case 3:
                        score = 750;
                        break;
                    case 4:
                        score = 1000;
                        break;
                    case 5:
                        score = 2000;
                        break;
                }
            }


            if (score > 0)
            {
                score += bet;
            }

            return score;
        }

        private bool CheckJacksOrBetter(List<Card> cards)
        {
            if (cards.Where(i => i.CardValue == CardValue.Jack).Count() >= 2 || cards.Where(i => i.CardValue == CardValue.Queen).Count() >= 2
                ||cards.Where(i => i.CardValue == CardValue.King).Count() >= 2 || cards.Where(i => i.CardValue == CardValue.Ass).Count() >= 2)
            {
                return true;
            }
            return false;
        }

        private bool Check3ofAKind(List<Card> cards)
        {
            for (int i = 7; i < 15; i++)
            {
                if (cards.Where(item => ((int)item.CardValue) == i).Count() == 3)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckStraight(List<Card> cards)
        {
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                if ((int)cards[i].CardValue + 1 == (int)cards[i + 1].CardValue)
                {
                    counter++;
                }
            }

            if (counter == 5)
            {
                return true;
            }

            return false;
        }

        private bool CheckFlush(List<Card> cards)
        {
            for (int i = 0; i < 4; i++)
            {
                if (cards.Where(item => (int)item.CardType == i).Count() == 4)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckFullHouse(List<Card> cards)
        {
            int counter = 0;
            for (int i = 7; i < 15; i++)
            {
                if (cards.Where(item => (int)item.CardValue == i).Count() >= 2)
                {
                    counter++;
                }
            }

            if (counter == 2)
            {
                return true;
            }

            return false;
        }

        private bool Check4ofAKind(List<Card> cards)
        {
            for (int i = 7; i < 15; i++)
            {
                if (cards.Where(item => ((int)item.CardValue) == i).Count() == 4)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckStraightFlush(List<Card> cards)
        {
            if (CheckStraight(cards) && CheckFlush(cards))
            {
                return true;
            }

            return false;
        }

        private bool CheckRoyalFlush(List<Card> cards)
        {

            if (cards.Where(i => i.CardType == CardType.Club).Count() == 5 || cards.Where(i => i.CardType == CardType.Diamond).Count() == 5
                || cards.Where(i => i.CardType == CardType.Heart).Count() == 5 || cards.Where(i => i.CardType == CardType.Spade).Count() == 5)
            {
                var values = cards.Select(i => i.CardValue);
                var valuesInInt = values.Select(i => Convert.ToInt32(i)).ToList();
                valuesInInt.Sort();
                int total = valuesInInt[0] + valuesInInt[1] + valuesInInt[2] + valuesInInt[3] + valuesInInt[4];
                if (total == 60 || total == 55 || total == 50 || total == 45)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
