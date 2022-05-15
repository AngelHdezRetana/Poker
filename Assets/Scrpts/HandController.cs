using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
    public GameObject prefab;
    public Transform point;
    public int cardLimit;

    private List<Card> cardsInHand;
    private bool blockCardCreation = false;// Bloquea la creación de cartas

    // Propiedades para la creacion de cartas en la mano
    private float spaceForCard = 0.4f;
    private float startDisplayXPosition = 0.0f;
    void Start() {
        cardsInHand = new List<Card>();
        StartCoroutine("loadHand");
    }

    void Update() {
        
    }

    IEnumerator loadHand() {
        for(int i = 0; i < cardLimit; i++) {
            Card card = Deck.drawCard();
            cardsInHand.Add(card);
            yield return new WaitForSeconds(1);
        }
        StartCoroutine("displayHand");
    }

    IEnumerator displayHand() {
        startDisplayXPosition = 0.0f;
        bool makeSpaceForCard = false;

        // Se establese el punto en X a partir de donde se empezaran a desplegar las cartas dependiendo del número de cartas en la mano
        foreach(Card card in cardsInHand) {
            if(!makeSpaceForCard) {
                makeSpaceForCard = true;
                continue;
            }

            makeSpaceForCard = false;
            startDisplayXPosition -= spaceForCard;
        }

        yield return null;
        StartCoroutine("instantiateCards");
    }

    IEnumerator instantiateCards() {
        // Se destruyen las cartas previamente desplegadas para no duplicarlas
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }
        // Se crean las cartas para desplegarse en la posicion a partir de "startDisplayXPosition"
        foreach(Card card in cardsInHand) {
            Vector2 instantiatePoint = new Vector2(startDisplayXPosition, point.position.y);
            GameObject cardObject = Instantiate(prefab, instantiatePoint, Quaternion.identity, gameObject.transform) as GameObject;

            // Se le asignan las propiedades al objeto instanciado de la carta
            cardObject.gameObject.name = $"card{cardsInHand.IndexOf(card)}";
            CardController cardController = cardObject.GetComponent<CardController>();
            cardController.setCard(card);
            startDisplayXPosition += spaceForCard;
        }
        yield return null;
    }

    public List<Card> getCardsInHand() {
        return cardsInHand;
    }
}
