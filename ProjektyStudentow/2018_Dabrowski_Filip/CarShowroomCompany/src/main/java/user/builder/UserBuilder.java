package user.builder;

import car.cars.Car;
import user.model.User;

import java.util.List;

public class UserBuilder {

    private User user;

    public UserBuilder() {
        this.user = new User();
    }

    public UserBuilder withUserName(String userName) {
        this.user.setUserName(userName);
        return this;
    }

    public UserBuilder withAge(int age) {
        this.user.setAge(age);
        return this;
    }

    public UserBuilder withAddress(String address) {
        this.user.setAddress(address);
        return this;
    }

    public UserBuilder withEmail(String email) {
        this.user.setEmail(email);
        return this;
    }

    public UserBuilder withPhoneNumber(int phoneNumber) {
        this.user.setPhoneNumber(phoneNumber);
        return this;
    }

    public UserBuilder withBoughtCars(List<Car> cars) {
        this.user.setBoughtCars(cars);
        return this;
    }

    public User buildUser() {
        return user;
    }

}
