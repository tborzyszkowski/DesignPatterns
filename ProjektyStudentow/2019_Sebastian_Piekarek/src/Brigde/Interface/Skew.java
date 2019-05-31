package Brigde.Interface;



import javax.swing.*;
import java.awt.*;
import java.awt.geom.AffineTransform;
import java.awt.image.BufferedImage;
import java.util.List;

public class Skew implements CardTilt {

    private double angle = 45;
    private JPanel playerSpace;

    public Skew(JPanel playerSpace){
        this.playerSpace = playerSpace;
    }

    @Override
    public void draw(BufferedImage cardImage) {

        double rads = Math.toRadians(angle);
        double sin = Math.abs(Math.sin(rads)), cos = Math.abs(Math.cos(rads));
        int w = cardImage.getWidth();
        int h = cardImage.getHeight();
        int newWidth = (int) Math.floor(w * cos + h * sin);
        int newHeight = (int) Math.floor(h * cos + w * sin);

        BufferedImage rotated = new BufferedImage(newWidth, newHeight, BufferedImage.TYPE_INT_ARGB);
        Graphics2D g2d = rotated.createGraphics();
        AffineTransform at = new AffineTransform();
        at.translate((newWidth - w) / 2, (newHeight - h) / 2);

        int x = w / 2;
        int y = h / 2;

        at.rotate(rads, x, y);
        g2d.setTransform(at);
        g2d.drawImage(cardImage, 0, 0, playerSpace);

        JLabel picLabel = new JLabel(new ImageIcon(rotated));
        playerSpace.add(picLabel);
        playerSpace.revalidate();
    }

    @Override
    public void drawHand(List<BufferedImage> cardsImages) {
        angle*=-1;
        for(BufferedImage image : cardsImages)
            draw(image);
    }
}
