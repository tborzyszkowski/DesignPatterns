package user.model;

import car.cars.Car;

import java.util.List;

public interface IUser {

    String getUserName();
    int getAge();
    String getAddress();
    String getEmail();
    int getPhoneNumber();
    List<Car> getBoughtCars();

}
