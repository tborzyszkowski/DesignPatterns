package com.company.Factory;

import com.company.Obserwator.Obserwator;
import com.company.Obserwator.Obserwowany;

import java.util.ArrayList;

public class Sheep extends Animal implements AnimalFactoryProtocol, Obserwowany {

    private ArrayList<Obserwator> obserwatorzy;

    public Sheep() {
        obserwatorzy = new ArrayList<Obserwator>();
        super.name = 'S';
    }

    @Override
    public Animal getAnimal() {
        return new Sheep();
    }

    @Override
    public void dodajObserwatora(Obserwator o) {
        obserwatorzy.add(o);
    }

    @Override
    public void usunObserwatora(Obserwator o) {
        int index = obserwatorzy.indexOf(o);
        obserwatorzy.remove(index);
    }

    @Override
    public void powiadamiajObserwatorow() {
        for(Obserwator o : obserwatorzy){
            o.update(super.direction);
        }
    }

    public void changeDirection(String changeTo) {
        super.direction = changeTo;
        powiadamiajObserwatorow();
    }
}
