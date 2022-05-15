using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController: MonoBehaviour {
    public List<Sprite> cardsSprite;
    private Card card;
    void Start() {

    }

    public Card getCard() {
        return card;
    }
    public void setCard(Card card) {
        this.card = card;
        setCardSprite();
    }

    public void setHidenCard(Card card) {
        this.card = card;
        string spriteName = "blue_deck";
        gameObject.GetComponent<SpriteRenderer>().sprite = cardsSprite.Find(s => s.name == spriteName);
        Debug.Log($"Hidden card spriteName: {spriteName}, card value {CardValueExtensions.getValueName(card.getValue())}{CardValueExtensions.getSymbol(card.getCardType())}");
    }

    private void setCardSprite() {
        string spriteName = $"{card.getValue()}_{card.getCardType()}";
        gameObject.GetComponent<SpriteRenderer>().sprite = cardsSprite.Find(s => s.name == spriteName);
        Debug.Log($"SpriteName: {spriteName}");
    }
}
