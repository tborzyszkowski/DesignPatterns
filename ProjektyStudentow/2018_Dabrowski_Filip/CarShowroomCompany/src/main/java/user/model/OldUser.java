package user.model;

import car.cars.Car;
import lombok.AllArgsConstructor;
import lombok.ToString;
import user.iterator.CarArrayIterator;
import user.iterator.CarIterator;

@ToString
@AllArgsConstructor
public class OldUser implements IOldUser {

    private String firstName;

    private String secondName;

    private int age;

    private String address;

    private String email;

    private int phoneNumber;

    private Car[] boughtCars;

    public CarIterator createIterator() {
        return new CarArrayIterator(boughtCars);
    }

    @Override
    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    @Override
    public String getSecondName() {
        return secondName;
    }

    public void setSecondName(String secondName) {
        this.secondName = secondName;
    }

    @Override
    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    @Override
    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    @Override
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Override
    public int getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(int phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    @Override
    public Car[] getBoughtCars() {
        return boughtCars;
    }

    public void setBoughtCars(Car[] boughtCars) {
        this.boughtCars = boughtCars;
    }
}
