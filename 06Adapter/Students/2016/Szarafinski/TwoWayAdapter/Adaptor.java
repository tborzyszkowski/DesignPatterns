/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AdapterTwoWay;

/**
 *
 * @author KrzysieK
 */
public class Adaptor extends AirCraft implements IAirCraft, ISeacraft {

    int speed;

    Adaptor() {
        speed = 0;
    }

    @Override
    public Boolean Airborne() {
        return height >= 200;
    }

    @Override
    public void TakeOff() {
        while (!Airborne()) {
            IncreaseRevs();
        }
        super.TakeOff();
    }

    @Override
    public void IncreaseRevs() {
        speed += 10;
        if (speed > 40) {
            height += 100;
        }
        System.out.println("Seacraft engine increases revs to " + speed + " knots");
    }

    @Override
    public int Speed() {
        return speed;
    }

    @Override
    public int Height() {
        return height;
    }

}
