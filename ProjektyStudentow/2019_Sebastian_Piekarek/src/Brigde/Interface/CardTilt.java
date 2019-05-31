package Brigde.Interface;

import java.awt.image.BufferedImage;
import java.util.List;

public interface CardTilt {

    void draw(BufferedImage cardImage);

    void drawHand(List<BufferedImage> cardsImages);

}
