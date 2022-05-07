using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Deck: System.Object {
    static List<Card> cards;
    static Deck() {
        // Genera todas las cartas dentro del deck
        cards = new List<Card>();
        foreach (CardType type in Enum.GetValues(typeof(CardType))) {
            foreach (CardValue value in Enum.GetValues(typeof(CardValue))) {
                cards.Add(new Card(type, value));
            }
        }
    }

    public static Card drawCard() {
        // Toma una carta al azar de la lista de cartas, la borra de la misma lista y la regresa
        System.Random random = new System.Random();
        Card cardDrawed = cards[random.Next(cards.Count)];
        cards.Remove(cardDrawed);

        // -------- Esto es solo una prueba
        String cardsText = "";
        foreach(Card card in cards) {
            String cardValue = CardValueExtensions.getValueName(card.getValue());
            String cardSymbol = CardValueExtensions.getSymbol(card.getCardType());
            cardsText += $", {cardValue}{cardSymbol}";
        }
        Debug.Log(cardsText);
        // -------------------------------


        return cardDrawed;
    }
}
