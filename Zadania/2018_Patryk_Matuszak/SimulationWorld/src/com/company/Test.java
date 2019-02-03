package com.company;

import com.company.Factory.*;

import static org.junit.Assert.*;

public class Test {


    //Singleton test
    @org.junit.Test
    public void getInstanceTest() {
        Map map1 = Map.getInstance();
        Map map2 = Map.getInstance();

        assertEquals(map1, map2);

        //Mapa jest singletonem.
    }

    //Factory test
    @org.junit.Test
    public void factoryTest() {
        Animal animal1 = AnimalFactory.getAnimal(new Wolf());
        Animal animal2 = AnimalFactory.getAnimal(new Sheep());

        assertEquals(animal1.name, 'W');
        assertEquals(animal2.name, 'S');

        //Tworzymy obiekt typu animal ale sprecyzowany do Wilka lub Owcy
    }


    //Observer test
    @org.junit.Test
    public void observerTest(){
        Animal sheep = new Sheep();
        Map map = new Map(sheep);

        ((Sheep) sheep).dodajObserwatora(map);
        ((Sheep) sheep).changeDirection("E");
        map.informuj();
        ((Sheep) sheep).changeDirection("N");
        map.informuj();

        //Jak widać Mapa reaguje na zmiany kierunku zwierzęcia.
    }
}