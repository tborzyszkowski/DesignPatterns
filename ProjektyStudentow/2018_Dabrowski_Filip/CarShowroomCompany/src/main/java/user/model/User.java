package user.model;

import car.cars.Car;
import lombok.ToString;
import user.iterator.CarIterator;
import user.iterator.CarListIterator;

import java.util.List;

@ToString
public class User implements IUser {

    private String userName;

    private int age;

    private String address;

    private String email;

    private int phoneNumber;

    private List<Car> boughtCars;

    public CarIterator createIterator() {
        return new CarListIterator(boughtCars);
    }

    @Override
    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public int getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(int phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public List<Car> getBoughtCars() {
        return boughtCars;
    }

    public void setBoughtCars(List<Car> boughtCars) {
        this.boughtCars = boughtCars;
    }
}
