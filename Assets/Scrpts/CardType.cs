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
    public static string getValueName(this int value) {
        switch (value) {
            case 11:
                return "J";
            case 12:
                return "Q";
            case 13:
                return "K";
            case 14:
                return "A";
            default:
                return $"{value}";
        }
    }

    public static string getSymbol(this CardType type) {
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
