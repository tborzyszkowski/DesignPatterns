package Facade.GUI;

import javax.swing.*;
import java.awt.*;
import java.util.List;

public class MainFrame extends JFrame {

    private TablePanel table;
    private static MainFrame mainFrame;

    private MainFrame(){
        super("Oczko");
        setLayout(new BorderLayout());

//        setExtendedState(JFrame.MAXIMIZED_BOTH);
        setSize(800, 830);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

    }

    public static MainFrame getMainFrame() {
        if(mainFrame == null)
            mainFrame = new MainFrame();
        return mainFrame;
    }

    public void setTable(List players){
        table = new TablePanel(players);
        add(table, BorderLayout.CENTER);
        setVisible(true);
    }

    @Override
    public void dispose() {
        super.dispose();
        mainFrame = new MainFrame();
    }
}
