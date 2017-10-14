/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package FactorySimple;

/**
 *
 * @author KrzysieK
 */
abstract public class Komputer {
    String model;
    String procesor;
    String ram;
    String monitor;
    
   
    @Override
    public String toString(){
        StringBuffer display = new StringBuffer();
        display.append("--- Dane modelu: " + model + " ---\n");
        display.append("Ram: " + ram + "\n");
        display.append("Procesor: " + procesor + "\n");
        display.append("Monitor: " + monitor + "\n");
        return display.toString();
    }
}
