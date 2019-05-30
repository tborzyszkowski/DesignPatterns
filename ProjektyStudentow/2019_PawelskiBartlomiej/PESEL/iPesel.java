package PESEL;
import Person.Person;

interface iPesel {
    void generate(Person person);
    boolean validate();
}
