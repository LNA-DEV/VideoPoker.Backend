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

            //First
            if (CheckJacksOrBetter(cardsList))
            {
                score += bet;
            }            

            //Last
            if (CheckRoyalFlush(cardsList))
            {
                switch (bet)
                {
                    case 1:
                        score += 250;
                        break;
                    case 2:
                        score += 500;
                        break;
                    case 3:
                        score += 750;
                        break;
                    case 4:
                        score += 1000;
                        break;
                    case 5:
                        score += 2000;
                        break;
                }
            }

            //score += CheckStraightFlush(cards);
            //score += Check4ofAKind(cards);
            //score += CheckFullHouse(cards);
            //score += CheckFlush(cards);
            //score += CheckStraight(cards);
            //score += Check2ofAKind(cards);

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

        private int Check2ofAKind(Card[] cards)
        {
            throw new NotImplementedException();
        }

        private int CheckStraight(Card[] cards)
        {
            throw new NotImplementedException();
        }

        private int CheckFlush(Card[] cards)
        {
            throw new NotImplementedException();
        }

        private int CheckFullHouse(Card[] cards)
        {
            throw new NotImplementedException();
        }

        private int Check4ofAKind(Card[] cards)
        {
            throw new NotImplementedException();
        }

        private int CheckStraightFlush(Card[] cards)
        {
            throw new NotImplementedException();
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
