package builderOrFactory.users;

public class User {

    public String userName;

    public int age;

    public String address;

    public String email;

    public int phoneNumber;

    @Override
    public String toString() {
        return "User{" +
                "userName='" + userName + '\'' +
                ", age=" + age +
                ", address='" + address + '\'' +
                ", email='" + email + '\'' +
                ", phoneNumber=" + phoneNumber +
                '}';
    }
}
