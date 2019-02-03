package com.company;

import com.company.Factory.Animal;
import com.company.Obserwator.Media;
import com.company.Obserwator.Obserwator;

public class Map implements Obserwator, Media {
    private static Map instance;
    private Animal animal;

    public Map(Animal animal) {
        this.animal = animal;
    }

    public Map(){}

    public static Map getInstance() {
        if (instance == null) {
            instance = new Map();
        }
        return instance;
    }

    String map[][] = new String[10][10];

    void createMap() {
        for (int i=0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                map[i][j] = "T";
            }
        }

        map[1][2] = "W";
        map[1][3] = "S";
    }

    @Override
    public void informuj() {
        System.out.println("Zmienilem kierunek");
        System.out.println(this.animal.direction);
        System.out.println();
    }

    @Override
    public void update(String dir) {

    }
}
