package design.paterns.objects;

public class Person implements Cloneable {

    private String name;
    private String surname;
    private Address address;
    public Person(String name, String surname) {
        this.name = name;
        this.surname = surname;
    }

    @Override
    protected Person clone() throws CloneNotSupportedException {
        Person newPerson = new Person(this.name, this.surname);
        newPerson.address = address.clone();
        return newPerson;
    }

    @Override
    public String toString() {
        return "Person{" +
                "name='" + name + '\'' +
                ", surname='" + surname + '\'' +
                ", address=" + address.toString() +
                '}';
    }

    public void setAddress(Address address) {
        this.address = address;
    }
}
