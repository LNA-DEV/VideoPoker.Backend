using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPoker.Backend.Cards;
using Xunit;

namespace VideoPoker.Backend.Test
{
    public class WinCheckerShould
    {
        [Fact]
        public void CheckWin()
        {
            //Arrange
            WinChecker winChecker = new ();
            Card[] cards = new Card[5];
            cards[0] = new Card(CardType.Club, CardValue.Ass);
            cards[1] = new Card(CardType.Club, CardValue.King);
            cards[2] = new Card(CardType.Club, CardValue.Queen);
            cards[3] = new Card(CardType.Club, CardValue.Jack);
            cards[4] = new Card(CardType.Club, CardValue.Ten);


            //Act
            var score = winChecker.CheckWin(cards, 5);

            //Assert
            score.ShouldBe(4000);
        }
    }
}
