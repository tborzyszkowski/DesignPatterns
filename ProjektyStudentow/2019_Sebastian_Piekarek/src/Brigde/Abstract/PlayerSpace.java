package Brigde.Abstract;

import Brigde.Interface.CardTilt;
import Prototype.Cards.Card;

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.TitledBorder;
import java.awt.*;
import java.util.ArrayList;
import java.util.List;
import java.awt.image.BufferedImage;
import java.io.IOException;

public abstract class PlayerSpace extends JPanel{

    protected CardTilt cardTilt;


    PlayerSpace(String name){
        Dimension dim = getPreferredSize();
        dim.width = 400;
        dim.height = 200;
        setPreferredSize(dim);
        setOpaque(false);
        Border innerBorder = BorderFactory.createTitledBorder(name);
        ((TitledBorder) innerBorder).setTitleColor(Color.WHITE);
        Border outerBorder = BorderFactory.createEmptyBorder(5,5,5,5);
        setBorder(BorderFactory.createCompoundBorder(innerBorder, outerBorder));
        setLayout(new FlowLayout());
        //        setLayout(new BoxLayout(this, BoxLayout.Y_AXIS));
    }

    protected BufferedImage loadImage(String name){
        BufferedImage image = null;
        try {
            image = ImageIO.read(this.getClass().getResource("images/"+ name + ".gif" ));
        } catch (IOException ex) {
            System.out.println("Problem z img karty" + name);
        }
        return image;
    }

    public void showHand(List<Card> cards){
        List<BufferedImage> cardsImages = new ArrayList<>();
        for (Card card : cards)
            cardsImages.add(loadImage(card.toString()));
        cardTilt.drawHand(cardsImages);
    }

    public abstract void drawCard(String name);



}
