using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    private List<Card> cardsInHand;
    public GameObject statusPanel; 

    void Start() {
        cardsInHand = new List<Card>();
    }

    public void updateCardsInHand(List<Card> cardsInHand) {
        this.cardsInHand = cardsInHand;
        // TODO: The logic to update the statusPanel info
    }
}
