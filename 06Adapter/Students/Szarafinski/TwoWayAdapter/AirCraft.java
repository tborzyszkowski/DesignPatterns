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
public class AirCraft implements IAirCraft {
    int height;
    boolean airborne;
    
    AirCraft(){
        height = 0;
        airborne = false;
    }
           
    @Override
    public Boolean Airborne() {
        return airborne;
    }

    @Override
    public void TakeOff() {
        System.out.println("Aircraft engne take off");
        airborne = true;
        height = 200;
    }

    @Override
    public int Height() {
        return height;
    }
    
}
