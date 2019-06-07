package Brigde.Abstract;


import Brigde.Interface.Straight;


public class HumanFields extends PlayerSpace {



    public HumanFields(String name) {
        super(name);
        this.cardTilt = new Straight(this);

    }

    @Override
    public void drawCard(String name) {
        cardTilt.draw(loadImage(name));
    }




}
