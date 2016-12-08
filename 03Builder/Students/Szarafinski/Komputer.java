/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Budowniczy;

/**
 *
 * @author KrzysieK
 */
public class Komputer {
    private String model;
    Monitor monitor;
    Ram ram;
    Procesor procesor;
    Grafika grafika;
    
    public Komputer(String model){
        this.model = model;
    }
    @Override
    public String toString(){
        StringBuffer display = new StringBuffer();
        display.append("--- Dane modelu: " + model + " ---\n");
        display.append("Ram: ").append(ram).append("\n");
        display.append("Procesor: " + procesor + "\n");
        display.append("Monitor: " + monitor + "\n");
        display.append("Grafika: " + grafika + "\n");
        return display.toString();
    }
    
    public void przygotuj() {
        System.out.println("Składam komputer, model nr: " + model);
    }

    public void pakuj() {
        System.out.println("Pakuję komputer, model nr: " + model);
    }
}
