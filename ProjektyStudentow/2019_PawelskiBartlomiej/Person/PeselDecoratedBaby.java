package Person;

import PESEL.*;

public class PeselDecoratedBaby extends PESELAdderDecorator {

    public PeselDecoratedBaby(Baby baby) {
        super();
        this.baby = baby;
        pesel.generate(baby);
    }

    @Override
    public String getName() {
        return null;
    }

    @Override
    public String getSurname() {
        return null;
    }

    @Override
    public String getDateOfBirth() {
        return null;
    }

    @Override
    public Sex getSex() {
        return null;
    }

    public Baby getBaby() {
        return baby;
    }

    public PESEL getPesel() {
        return pesel;
    }

    public String getPeselString(){
        return pesel.toString();
    }

    @Override
    public String toString() {
        return (baby.getName() + " " + baby.getSurname() + " ur. " + baby.getDateOfBirth() + " - nadano PESEL: " + this.getPeselString());
    }
}
