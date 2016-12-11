/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package FactoryAbstract;

/**
 *
 * @author KrzysieK
 */
abstract public class Komputer {
    private String model;

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }
    Monitor monitor;
    Ram ram;
    Procesor procesor;
    Dodatek dodatek;
    
    @Override
    public String toString(){
        StringBuffer display = new StringBuffer();
        display.append("--- Dane modelu: " + model + " ---\n");
        display.append("Ram: " + ram + "\n");
        display.append("Procesor: " + procesor + "\n");
        display.append("Monitor: " + monitor + "\n");
        display.append("Dodatek: " + dodatek + "\n");
        return display.toString();
    }
    
    public void przygotuj() {
        System.out.println("Składam komputer, model nr: " + model);
    }

    public void pakuj() {
        System.out.println("Pakuję komputer, model nr: " + model);
    }
}
