package Brigde.Interface;


import javax.swing.*;
import java.awt.image.BufferedImage;
import java.util.List;

public class Straight implements CardTilt {

    private JPanel playerSpace;

    public Straight(JPanel playerSpace){
        this.playerSpace = playerSpace;
    }

    @Override
    public void draw(BufferedImage cardImage) {
        JLabel picLabel = new JLabel(new ImageIcon(cardImage));
        playerSpace.add(picLabel);
        playerSpace.revalidate();
    }

    @Override
    public void drawHand(List<BufferedImage> cardsImages) {
        for(BufferedImage image : cardsImages)
            draw(image);
    }
}
