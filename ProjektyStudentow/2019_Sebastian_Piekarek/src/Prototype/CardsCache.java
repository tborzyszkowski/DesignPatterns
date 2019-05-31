package Prototype;

import Prototype.Cards.*;

import java.util.Hashtable;

public class CardsCache {

    private Hashtable<Integer, Card> cardTypes  = new Hashtable<Integer, Card>();

    public Card getCard(int cardID) {
        Card cachedShape = cardTypes.get(cardID);
        return (Card) cachedShape.clone();
    }


    public void loadCache() {
        cardTypes.put(2, new Two());
        cardTypes.put(3, new Three());
        cardTypes.put(4, new Four());
        cardTypes.put(5, new Five());
        cardTypes.put(6, new Six());
        cardTypes.put(7, new Seven());
        cardTypes.put(8, new Eight());
        cardTypes.put(9, new Nine());
        cardTypes.put(10, new Ten());
        cardTypes.put(11, new Jack());
        cardTypes.put(12, new Queen());
        cardTypes.put(13, new King());
        cardTypes.put(14, new Ace());
    }


}