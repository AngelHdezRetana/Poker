using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public static class Extensions {
    public static int findIndex<T>(this T[] array, T item) {
        return Array.IndexOf(array, item);
    }
}

public class TableController: MonoBehaviour {
    public int cardTableLimit;
    private Card[] cardsInTable;
    public Transform point;
    public GameObject prefab;
    private bool isCardRevelationBlocked;// Bloquea la revelación de cartas

    private float spaceForCard = 0.4f;
    private float startDisplayXPosition = 0.0f;
    void Start() {
        cardsInTable = new Card[cardTableLimit];
        isCardRevelationBlocked = false;
        displayDefaultCards();
    }

    // Update is called once per frame
    void Update() {
        if (!isCardRevelationBlocked) {
            if (Input.GetKeyDown(KeyCode.A)) {
                isCardRevelationBlocked = true;
                revealOneCardFromTable();
            }
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            isCardRevelationBlocked = false;
        }
    }

    private void displayDefaultCards() {
        startDisplayXPosition = 0.0f;
        bool makeSpaceForCard = false;

        // Se establese el punto en X a partir de donde se empezaran a desplegar las cartas dependiendo del número de cartas en la mano
        foreach (Card card in cardsInTable) {
            if (!makeSpaceForCard) {
                makeSpaceForCard = true;
                continue;
            }

            makeSpaceForCard = false;
            startDisplayXPosition -= spaceForCard;
        }

        // Se destruyen las cartas previamente desplegadas para no duplicarlas
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        // Se crean las cartas para desplegarse en la posicion a partir de "startDisplayXPosition"
        foreach (Card card in cardsInTable) {
            Vector2 instantiatePoint = new Vector2(startDisplayXPosition, point.position.y);
            GameObject cardObject = Instantiate(prefab, instantiatePoint, Quaternion.identity, gameObject.transform) as GameObject;
            if (card != null) {
                CardController cardController = cardObject.GetComponent<CardController>();
                cardController.setCard(card);
            }
            startDisplayXPosition += spaceForCard;
        }
    }

    private void revealOneCardFromTable() {
        // En caso de que exista una carta nula en la mesa (es decir, una carta boca abajo) se toma el indice de dicha carta
        // y se remplaza por una del deck
        if (cardsInTable.Contains(null)) {
            Card nullCardObject = cardsInTable.Where(card => card == null) as Card;
            int nullIndex = cardsInTable.findIndex(nullCardObject);
            cardsInTable[nullIndex] = Deck.drawCard();
            displayDefaultCards();
        }
    }
}
