using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType {
    heart,
    diamon,
    spade,
    club
}

public enum CardColor {
    red,
    black
}

public enum CardValue {
    two = 2,
    three = 3,
    four = 4,
    five = 5,
    six = 6,
    seven = 7,
    eight = 8,
    nine = 9,
    ten = 10,
    jack = 11,
    queen = 12,
    king = 13,
    ace = 14
}

public static class CardValueExtensions {
    private static string getValueName(this CardValue value) {
        switch (value) {
            case CardValue.jack:
                return "J";
            case CardValue.queen:
                return "Q";
            case CardValue.king:
                return "K";
            case CardValue.ace:
                return "A";
            default:
                return $"{value}";
        }
    }

    private static string getSymbol(this CardType type) {
        switch (type) {
            case CardType.heart:
                return "♥";
            case CardType.diamon:
                return "♦";
            case CardType.spade:
                return "♠";
            case CardType.club:
                return "♣";
            default:
                return "";
        }
    }
}
