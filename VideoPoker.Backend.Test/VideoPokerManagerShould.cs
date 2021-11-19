using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace VideoPoker.Backend.Test
{
    public class VideoPokerManagerShould
    {
        [Fact]
        public void GetRandomCardValue()
        {
            //Arrange
            List<CardValue> cards = new List<CardValue>();
            VideoPokerManager videoPokerManager = new VideoPokerManager();

            //Act
            for (int i = 0; i < 100; i++)
            {
                cards.Add(videoPokerManager.GetRandomCardValue());
            }

            //Assert
            cards.ShouldNotBeEmpty();
            cards.Where(i => i == CardValue.Eight).ShouldNotBeEmpty();
            cards.Where(i => i == CardValue.King).ShouldNotBeEmpty();
            cards.Where(i => i == CardValue.Jack).ShouldNotBeEmpty();
            cards.Where(i => i == CardValue.Queen).ShouldNotBeEmpty();
            cards.Where(i => i == CardValue.Nine).ShouldNotBeEmpty();
            cards.Where(i => i == CardValue.Seven).ShouldNotBeEmpty();
            cards.Where(i => i == CardValue.Nine).ShouldNotBeEmpty();
            cards.Where(i => i == CardValue.Ten).ShouldNotBeEmpty();
        }

        [Fact]
        public void GetRandomCardType()
        {
            //Arrange
            List<CardType> cards = new List<CardType>();
            VideoPokerManager videoPokerManager = new VideoPokerManager();

            //Act
            for (int i = 0; i < 100; i++)
            {
                cards.Add(videoPokerManager.GetRandomCardType());
            }

            //Assert
            cards.ShouldNotBeEmpty();
            cards.Where(i => i == CardType.Heart).ShouldNotBeEmpty();
            cards.Where(i => i == CardType.Diamond).ShouldNotBeEmpty();
            cards.Where(i => i == CardType.Club).ShouldNotBeEmpty();
            cards.Where(i => i == CardType.Spade).ShouldNotBeEmpty();
        }
    }
}
