package Facade;

import ChainOfResponsibility.*;

import Facade.GUI.MainFrame;
import Singleton.SingletonDeck;
import Template.*;


import javax.swing.*;
import java.util.*;
import java.util.List;


public class Game {

    private SingletonDeck singletonDeck;
    private int playersNumber;
    private List<Player> players = new ArrayList<>();
    Stage prepare = new Prepare();
    Stage round = new Round();
    Stage gameOver = new GameOver();


    public Game(){
        playersNumber = numOfPlayersDialog();
        initPlayers();
        initGameGraphic();
        this.singletonDeck = SingletonDeck.getDeck();
        singletonDeck.shuffle();
        setChainStages();
    }

    public void start(){

        prepare.procedure(players);

    }

    public void setChainStages(){
        prepare = new Prepare();
        round = new Round();
        gameOver = new GameOver();

        prepare.setNextStage(round);
        round.setNextStage(gameOver);

    }

    private int numOfPlayersDialog(){
        JDialog.setDefaultLookAndFeelDecorated(true);
        Object[] selectionValues = { 1, 2, 3 };
        int initialSelection = 0;
        Object selection = JOptionPane.showInputDialog(null, "Z iloma komputerami chcesz zagrać?",
                "Liczba graczy", JOptionPane.QUESTION_MESSAGE, null, selectionValues, initialSelection);
        return (int)selection;
    }

    private void initPlayers(){
        players.add(new Human("Gracz"));

        for(int i = 1; i <= playersNumber; i++)
        {
            players.add(new Computer("Komputer " + i) {
            });
        }
    }

    private void initGameGraphic(){
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                MainFrame mainFrame = MainFrame.getMainFrame();
                mainFrame.setTable(players);
            }
        });
    }
}
