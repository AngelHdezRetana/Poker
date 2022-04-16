using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

interface CardFactory {
    Card createCard();
}

class RandomCardFactory: CardFactory {
    public Card createCard() {
        CardColor cardColor;
        Array cardValues = Enum.GetValues(typeof(CardValue));
        Array cardTypes = Enum.GetValues(typeof(CardType));
        System.Random random = new System.Random();

        CardValue cardValue = (CardValue) cardValues.GetValue(random.Next(cardValues.Length));
        CardType cardType = (CardType) cardTypes.GetValue(random.Next(cardTypes.Length));

        return new Card(cardType, cardValue);
    }
}

class HeartCardFactory: CardFactory {
    public Card createCard() {
        Array cardValues = Enum.GetValues(typeof(CardValue));
        System.Random random = new System.Random();
        CardValue cardValue = (CardValue) cardValues.GetValue(random.Next(cardValues.Length));
        
        return new Card(CardType.heart, cardValue);
    }
}

class DiamonCardFactory: CardFactory {
    public Card createCard() {
        Array cardValues = Enum.GetValues(typeof(CardValue));
        System.Random random = new System.Random();
        CardValue cardValue = (CardValue)cardValues.GetValue(random.Next(cardValues.Length));

        return new Card(CardType.diamon, cardValue);
    }
}

class ClubCardFactory: CardFactory {
    public Card createCard() {
        Array cardValues = Enum.GetValues(typeof(CardValue));
        System.Random random = new System.Random();
        CardValue cardValue = (CardValue)cardValues.GetValue(random.Next(cardValues.Length));

        return new Card(CardType.club, cardValue);
    }
}

class SpadeCardFactory: CardFactory {
    public Card createCard() {
        Array cardValues = Enum.GetValues(typeof(CardValue));
        System.Random random = new System.Random();
        CardValue cardValue = (CardValue)cardValues.GetValue(random.Next(cardValues.Length));

        return new Card(CardType.spade, cardValue);
    }
}