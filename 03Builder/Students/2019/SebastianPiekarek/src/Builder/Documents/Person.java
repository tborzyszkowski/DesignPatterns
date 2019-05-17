package Builder.Documents;

public class Person {
    public String name;
    public String surname;
    public String street;
    public String address;
    public String phoneNumber;
    public String email;

    private String gap = "                                         ";

    public Person(String name, String surname, String street, String address, int phoneNumber, String email, boolean sender){
        this.surname = surname;
        if (sender) {
            this.name = name;
            this.street = street;
            this.address = address;
            this.phoneNumber = ""+phoneNumber;
            this.email = email;
        }else
        {
            this.name = gap + name;
            this.street = gap + street;
            this.address = gap + address;
            this.phoneNumber = gap + phoneNumber;
            this.email = gap + email;
        }
    }

    @Override
    public String toString() {
        return  "\n| " + name + " " + surname +
                "\n| " + street +
                "\n| " + address +
                "\n| " + phoneNumber +
                "\n| " + email;
    }
}
