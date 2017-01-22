/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projekt;

import java.util.ArrayList;

/**
 *
 * @author KrzysieK
 */
public class Menu {
    private ArrayList<String> menu = new ArrayList<>();

    public ArrayList<String> getMenu() {
        return menu;
    }
    
    public Menu(){
        menu.add("Krewetki królewskie na maśle czosnkowym");
        menu.add("Zupa rakowa po królewsku");
        menu.add("Żurek po polsku z borowikami z dodatkiem bezglutenowego pieczywa");
        menu.add("Łosoś królewski z ruszt z pieczonymi ziemniakami");
        menu.add("Sandacz smażony z grzybami z polskiego lasu");
        menu.add("Przysmak Króla Zygmunta - zrazy wołowe");
        menu.add("Kaczka z konfiturą wiśniową i jabłkiem pieczonym");
        menu.add("Soczyste panierowane polędwiczki z kurczaka podane z frytkami i surówką");
    }
    
    public void dodaj(String pozycja){
        menu.add(pozycja);
    }
    
    
    @Override
    public String toString(){
        return menu.toString();
    }
}
