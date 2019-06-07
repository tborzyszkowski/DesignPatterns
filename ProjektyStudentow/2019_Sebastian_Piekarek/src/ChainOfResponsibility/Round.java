package ChainOfResponsibility;

import Singleton.SingletonDeck;
import Template.Player;

import java.util.List;

public class Round implements Stage {

    private Stage nextStage;
    private boolean gameContinues = true;

    @Override
    public void setNextStage(Stage nextStage) {
        this.nextStage = nextStage;
    }

    @Override
    public void procedure(List players) {

            while(!SingletonDeck.getDeck().cards.empty() && gameContinues && gameOn(players)){
                for(Object player: players){
                    if(((Player)player).isStatus() && gameContinues) gameContinues = ((Player)player).play();
                }
            }
            revealCards(players);

            nextStage.procedure(players);

    }

    private boolean gameOn(List<Player> players){
        for(Player player: players)
            if(player.isStatus()) return true;
        return false;
    }

    private void revealCards(List<Player> players){
        for (Player player : players)
            player.revealHand();
    }


}
