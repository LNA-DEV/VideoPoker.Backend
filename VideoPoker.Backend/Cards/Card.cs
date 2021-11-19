namespace VideoPoker.Backend.Cards
{
    public class Card
    {
        public Card(CardType cardType, CardValue cardValue, bool isHold)
        {
            this.CardType = cardType;
            this.CardValue = cardValue;
        }

        public CardType CardType { get; set; }
        public CardValue CardValue { get; set; }
    }
}
