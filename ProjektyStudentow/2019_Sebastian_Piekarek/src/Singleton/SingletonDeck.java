package Singleton;

import Prototype.Cards.Card;
import Prototype.CardsCache;
import java.util.*;

public class SingletonDeck {

    private static SingletonDeck singletonDeck;
    public Stack<Card> cards = new Stack<>();
    private String[] colors = {"c","d","h","s"};

    private SingletonDeck(){}

    public static SingletonDeck getDeck(){
        if(singletonDeck == null){
            singletonDeck = new SingletonDeck();
            singletonDeck.completeDeck();
        }
        return singletonDeck;
    }


    private void completeDeck(){
        CardsCache cardsCache = new CardsCache();
        cardsCache.loadCache();
        for(String color : colors) {
            for(int i = 2; i <= 14; i++) {
                cards.add(cardsCache.getCard(i).setColor(color));
            }
        }
    }

    public void resetDeck(){
        cards = new Stack<>();
        completeDeck();

    }

    public void shuffle(){
        Collections.shuffle(cards);
    }

}
