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

    private void setCardSprite() {
        string spriteName = $"{card.getValue()}_{card.getCardType()}";
        gameObject.GetComponent<SpriteRenderer>().sprite = cardsSprite.Find(s => s.name == spriteName);
        Debug.Log($"SpriteName: {spriteName}");
    }
}
