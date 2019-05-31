package Brigde.Abstract;

import Brigde.Interface.Skew;

import java.awt.image.BufferedImage;

public class ComputerFields extends PlayerSpace {

    private final BufferedImage cardBack;

    public ComputerFields(String name) {
        super(name);
        this.cardTilt = new Skew(this);
        cardBack = loadImage("back");
    }

    @Override
    public void drawCard(String name) {
        cardTilt.draw(loadImage(name));
    }

    public void drawCard() {
        cardTilt.draw(cardBack);
    }
}
