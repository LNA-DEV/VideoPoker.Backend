﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPoker.Backend
{
    public class Card
    {
        public Card(CardType cardType, CardValue cardValue, bool isHold)
        {
            this.CardType = cardType;
            this.CardValue = cardValue;
            this.IsHold = isHold;
        }

        public CardType CardType { get; set; }
        public CardValue CardValue { get; set; }
        public bool IsHold { get; set; }
    }
}
