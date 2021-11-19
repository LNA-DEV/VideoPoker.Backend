using Shouldly;
using System.Collections.Generic;
using System.Linq;
using VideoPoker.Backend.Cards;
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

        [Fact]
        public void Deal()
        {
            //Arrange
            VideoPokerManager videoPokerManager = new VideoPokerManager();

            //Act
            var cards = videoPokerManager.Deal();

            //Assert
            for (int i = 0; i < cards.Length; i++)
            {
                for (int j = cards.Length - 1; j <= 0; j--)
                {
                    if (cards[i].CardValue == cards[j].CardValue && cards[i].CardType == cards[j].CardType)
                    {
                        Assert.True(false);
                    }
                }
            }
            cards.Length.ShouldBeLessThan(6);
        }
    }
}
