/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Fasada;

/**
 *
 * @author KrzysieK
 */
public class Obiad extends Danie{
    Obiad() {
        nazwa = "Schabowy z ziemniakami";
        domyslneSkladniki();
        cena = 17.98;
    }

    private void domyslneSkladniki() {
        skladniki.add("Ziemniaki");
        skladniki.add("Koperek");
        skladniki.add("Buraczki");
        skladniki.add("Cebula");
        skladniki.add("Schabowy");
    }
}
