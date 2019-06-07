package Facade.GUI;

import Template.Player;

import javax.swing.*;
import java.awt.*;
import java.util.List;

public class TablePanel extends JPanel {

    private String[] sides = { BorderLayout.SOUTH, BorderLayout.WEST, BorderLayout.NORTH, BorderLayout.EAST  };


    public TablePanel(List<Player> players){
        setLayout(new BorderLayout());
        Color  green   = new Color(0, 117,  22);
        setBackground(green);

        for(int i = 0; i < players.size(); i++)
        {
            add(players.get(i).getPlayerSpace(), sides[i]);
        }
    }
}
