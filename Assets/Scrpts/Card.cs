using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Card {
    private int value;
    private CardType cardType;
    private CardColor color;

    public Card(CardType cardType, CardValue value) {
        this.value = (int)value;
        this.cardType = cardType;
        color = (cardType == CardType.club || cardType == CardType.spade) ? CardColor.black : CardColor.red;
    }

    public int getValue() {
        return value;
    }

    public CardType getCardType() {
        return cardType;
    }

    public CardColor getCardColor() {
        return color;
    }
}