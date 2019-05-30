import PESEL.*;
import Person.*;
import PersonListAdapter.*;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;

class Tests {

    private ArrayList<Person> testList() {
        ArrayList<Person> list = new ArrayList<>();
        list.add(new Baby("Krzysztof", "Dąbrowski", "28-05-2019", Sex.MALE));
        list.add(new Baby("Joanna", "Nowak", "28-05-2019", Sex.FEMALE));
        list.add(new Baby("Dawid", "Bekcham", "28-05-2019", Sex.MALE));
        list.add(new Baby("Katarzyna", "Winnicka", "29-05-2019", Sex.FEMALE));
        list.add(new Baby("Piotr", "Stawski", "29-05-2019", Sex.MALE));
        list.add(new Baby("Andżelika", "Prosta", "29-05-2019", Sex.FEMALE));
        return list;
    }

    private PersonsCSV personsCSV() {
        return new PersonsCSV(PersonsCSV.listOfPersonToCSV(testList()));
    }

    private PersonsJSON personsJSON() {
        return new PersonsJSON(PersonsJSON.listOfPersonToJSON(testList()));
    }

    @Test
    void validateStringPesel() {
        //przykład ze strony przykladowe.pl/pesel
        PESEL testPESEL = new PESEL("90090515836");
        Assertions.assertTrue(testPESEL.validate());
    }

    @Test
    void generatePesel() {
        PESEL testPESEL = new PESEL();
        testPESEL.generate(new Baby("Jan", "Kowalski", "12-01-1995", Sex.MALE));
        Assertions.assertTrue(testPESEL.validate());
    }

    @Test
    void generatePeselForBaby1() {
        Baby baby1 = new Baby("Ania", "Kowalska", "19-05-2019", Sex.FEMALE);
        PeselDecoratedBaby decoratedBaby1 = new PeselDecoratedBaby(baby1);
        Assertions.assertTrue(decoratedBaby1.getPesel().validate());
    }

    @Test
    void generatePeselForBabyListCSV() {
        System.out.println("\n ---CSV---");
        PersonListAdapter adapter = new PersonListAdapter(personsCSV());
        ArrayList<Person> list = adapter.getPersonsList.apply(personsCSV().getPersonCSV());
        ArrayList<PeselDecoratedBaby> list2 = PersonListAdapter.addPeselsToList(list);
        list2.forEach(baby -> System.out.println(baby.toString()));
    }

    @Test
    void generatePeselForBabyListJSON() {
        System.out.println("\n ---JSON---");
        PersonListAdapter adapter = new PersonListAdapter(personsJSON());
        ArrayList<Person> list = adapter.getPersonsList.apply(personsJSON().getPersonJSON());
        ArrayList<PeselDecoratedBaby> list2 = PersonListAdapter.addPeselsToList(list);
        list2.forEach(baby -> System.out.println(baby.toString()));
    }



}

