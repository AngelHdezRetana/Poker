using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentHandController : MonoBehaviour {
    public GameObject table;
    public GameObject prefab;
    public int cardLimit = 2;
    public Transform point;
    private List<Card> cardsInHand;

    private TableController tableController;

    // Propiedades para la creacion de cartas en la mano
    private float spaceForCard = 0.4f;
    private float startDisplayXPosition = 0.0f;

    void Start() {
        cardsInHand = new List<Card>();
        tableController = table.GetComponent<TableController>();
        StartCoroutine("loadHand");
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            if(tableController.allCardsInTableAreRevealed()) {
                StartCoroutine("displayHand");
            }
        }
    }

    IEnumerator loadHand() {
        for(int i = 0; i < cardLimit; i++) {
            Card card = Deck.drawCard();
            cardsInHand.Add(card);
            yield return new WaitForSeconds(.5f);
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
            Debug.Log($"Cartas de la mesa reveladas: {tableController.allCardsInTableAreRevealed()}");
            if(tableController.allCardsInTableAreRevealed()) {
                // Si no se han revelado todas las cartas en la mesa la mano del oponente no se revela
                cardController.setCard(card);
            } else {
                cardController.setHidenCard(card);
            }
            startDisplayXPosition += spaceForCard;
        }
        yield return null;
    }

    IEnumerator showHand() {
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
            cardController.setHidenCard(card);
            startDisplayXPosition += spaceForCard;
        }
        yield return null;
    }
}
