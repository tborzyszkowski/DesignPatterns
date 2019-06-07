package ChainOfResponsibility;

import Facade.Game;
import Facade.GUI.MainFrame;
import Singleton.SingletonDeck;
import Template.Player;

import javax.swing.*;
import java.util.ArrayList;
import java.util.List;

public class GameOver implements Stage {

    private Stage nextStage;

    @Override
    public void setNextStage(Stage nextStage) {
        this.nextStage = nextStage;
    }

    @Override
    public void procedure(List players) {

            List<String> winners = new ArrayList<>();
            int highScore = 0;
            String bestPlayer = "";
            for (Object player : players) {
                if (((Player)player).getScore() > 21) continue;
                if (((Player)player).getScore() > highScore) {
                    highScore = ((Player)player).getScore();
                    bestPlayer = player.toString();
                    winners.removeAll(winners);
                    winners.add(player.toString());
                } else if (((Player)player).getScore() == highScore) winners.add(player.toString());
            }
            if(winners.size() > 1) endGame("Remis - " + winners );
            else if(bestPlayer.equals("")) endGame("Nikt nie wygrał :( ");
            else endGame(bestPlayer);
    }

    private void endGame(String winner){
        Object[] options = {"Reset", "Exit"};
        int n = JOptionPane.showOptionDialog(null,
                winner + ".",
                "Game over",
                JOptionPane.YES_NO_OPTION,
                JOptionPane.QUESTION_MESSAGE,
                null,
                options,
                options[0]);
        if(n == 0 ) {
            MainFrame.getMainFrame().dispose();
            SingletonDeck.getDeck().resetDeck();
            SingletonDeck.getDeck().shuffle();
            new Game().start();
        }else
            System.exit(0);
    }


}
