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
public class SeaCraft implements ISeacraft {

    int speed;

    SeaCraft() {
        speed = 0;
    }

    @Override
    public int Speed() {
        return speed;
    }

    @Override
    public void IncreaseRevs() {
        speed += 10;
        System.out.println("Seacraft engine increases revs to " + speed + " knots");
    }

}
