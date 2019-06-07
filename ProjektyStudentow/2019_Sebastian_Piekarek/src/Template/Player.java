package Template;

import Brigde.Abstract.PlayerSpace;
import Prototype.Cards.Card;
import Singleton.SingletonDeck;

import java.util.ArrayList;
import java.util.List;

public abstract class Player {

    private String playerID;
    protected int score;
    protected List<Card> playerCards = new ArrayList<>();
    private boolean status = true;
    protected PlayerSpace playerSpace;
    private SingletonDeck deck;

    Player(String playerID){
        this.playerID = playerID;
        score = 0;
        deck = SingletonDeck.getDeck();
    }

    abstract boolean decision();
    abstract void drawCard();

    public boolean play(){
        if(status){
            if(decision()){
                takeCard();
                score = countScore(playerCards);
            } else status = false;

            if(score == 21){
//                System.out.println(playerID + " wygrywa!");
                status = false;
                return false;
            } else if(score > 21) status = false;
        }
        return true;
    }


    public static int countScore(List<Card> hand){
        int score = 0;
        for(Card card : hand){
            score += card.getValue();
        }
        return score;
    }

    public void takeCard(){
        playerCards.add(deck.cards.pop());
        drawCard();
    }

    public boolean isStatus() {
        return status;
    }

    public PlayerSpace getPlayerSpace() {
        return playerSpace;
    }

    public int getScore() {
        return score;
    }

    @Override
    public String toString() {
        return playerID + " wygrywa z wynikiem " + score;
    }


    public void revealHand(){
        playerSpace.removeAll();
        playerSpace.showHand(playerCards);

    }
}
