package PersonListAdapter;
import PESEL.Sex;
import Person.*;

import java.util.ArrayList;

public class PersonsCSV {
    private String personsCSV;

    public PersonsCSV(String personCSV) {
        this.personsCSV = personCSV;
    }

    public String getPersonCSV() {
        return personsCSV;
    }

    public void setPersonCSV(String personCSV) {
        this.personsCSV = personCSV;
    }

    @Override
    public String toString() {
        return "PersonsCSV{" +
                "personsCSV='" + personsCSV + '\'' +
                '}';
    }

    public static String listOfPersonToCSV(ArrayList<Person> list) {
        String output = "";
        for (Person person : list) {
            output = output.concat(person.getName() + ", " + person.getSurname() + ", " + person.getDateOfBirth() + ", " + person.getSex() + "\n");
        }
        return output;
    }
}
