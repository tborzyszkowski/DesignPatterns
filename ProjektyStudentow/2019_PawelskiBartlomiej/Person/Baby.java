package Person;
import PESEL.Sex;

public class Baby extends Person {
    private String name;
    private String surname;
    private String dateOfBirth; // date in format dd-mm-yyyy
    private Sex sex;

    public Baby(String name, String surname, String dateOfBirth, Sex sex) {
        this.name = name;
        this.surname = surname;
        this.dateOfBirth = dateOfBirth;
        this.sex = sex;
    }

    public String getName() {
        return name;
    }

    public String getSurname() {
        return surname;
    }

    public String getDateOfBirth() {
        return dateOfBirth;
    }

    public Sex getSex() {
        return sex;
    }

    @Override
    public String toString() {
        return (name + " " + surname + " ur. " + dateOfBirth);
    }
}
