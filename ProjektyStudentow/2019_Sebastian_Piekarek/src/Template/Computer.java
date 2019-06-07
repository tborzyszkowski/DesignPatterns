package Template;


import Brigde.Abstract.ComputerFields;

import java.util.Random;

public class Computer extends Player {


    public Computer(String playerID) {
        super(playerID);
        this.playerSpace = new ComputerFields((playerID));
    }


    @Override
    boolean decision() {
        try
        {
            Thread.sleep(new Random().nextInt(500) +300);
        }
        catch(InterruptedException ex)
        {
            Thread.currentThread().interrupt();
        }
        double probability = 1.25 - score/21.00;
        return Math.random() < probability ;
    }


    @Override
    void drawCard() {
        ((ComputerFields)playerSpace).drawCard();
    }


}
