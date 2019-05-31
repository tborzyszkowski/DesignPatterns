package ChainOfResponsibility;

import Template.Player;

import java.util.List;

public class Prepare implements Stage {
    private Stage nextStage;

    @Override
    public void setNextStage(Stage nextStage) {
        this.nextStage = nextStage;
    }

    @Override
    public void procedure(List players) {

            for (Object player : players){
                ((Player)player).takeCard();
            }
            nextStage.procedure(players);
    }


}
