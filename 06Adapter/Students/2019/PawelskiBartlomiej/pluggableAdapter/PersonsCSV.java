package pluggableAdapter;

import java.util.ArrayList;

public class PersonsCSV {
    private String personsCSV;

    public PersonsCSV(String personJSON) {
        this.personsCSV = personJSON;
    }

    public String getPersonCSV() {
        return personsCSV;
    }

    public void setPersonCSV(String personJSON) {
        this.personsCSV = personJSON;
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
            output = output.concat(person.getName() + ", " + person.getSurname() + ", " + person.getAge() + "\n");
        }
        return output;
    }
}

