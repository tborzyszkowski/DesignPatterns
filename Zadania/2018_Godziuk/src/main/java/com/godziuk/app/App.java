package com.godziuk.app;

import com.godziuk.app.Organizm.*;
import com.godziuk.app.Plansza.Plansza;
import com.godziuk.app.Organizm.OrganizmInterface;
/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        System.out.println( "Witaj w grze!" );
        
        //----------------------tworzenie planszy----------------------------
        Plansza plansza = Plansza.getInstance();
        
        //----------------------tworzenie organizmow-------------------------
        OrganizmBuilderInterface owcaBuilder = new OwcaBuilder();
        OrganizmBuilderInterface trawaBuilder = new TrawaBuilder();
        OrganizmBuilderInterface wilkaBuilder = new WilkBuilder();
        
        Stworca stworcaOwiec = new Stworca(owcaBuilder);
        Stworca stworcaTrawy = new Stworca(trawaBuilder);
        Stworca stworcaWilkow = new Stworca(wilkaBuilder);
        
        stworcaOwiec.createOrganizm();
        stworcaTrawy.createOrganizm();
        stworcaWilkow.createOrganizm();
        
        Organizm owca = stworcaOwiec.getOrganizm();
        Organizm trawa = stworcaTrawy.getOrganizm();
        Organizm wilk = stworcaWilkow.getOrganizm();
        
        System.out.println(trawa.toString());
        System.out.println(wilk.toString());
        System.out.println(owca.toString());
        
        //---------------------przypisywanie organizmow do pol-----------------
        
        
    }
}
