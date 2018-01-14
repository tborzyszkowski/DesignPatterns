package design.paterns.objects;

public class Address implements Cloneable{

    private String street;
    private String number;

    public Address(String street, String number) {
        this.street = street;
        this.number = number;
    }

    @Override
    protected Address clone() throws CloneNotSupportedException {
        Address address = new Address(this.street, this.number);
        return address;
    }

    @Override
    public String toString() {
        return "Address{" +
                "street='" + street + '\'' +
                ", number='" + number + '\'' +
                '}';
    }
}
