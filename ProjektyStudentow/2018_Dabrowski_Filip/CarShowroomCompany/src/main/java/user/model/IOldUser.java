package user.model;

import car.cars.Car;

public interface IOldUser {

    String getFirstName();
    String getSecondName();
    int getAge();
    String getAddress();
    String getEmail();
    int getPhoneNumber();
    Car[] getBoughtCars();
    void setBoughtCars(Car[] boughtCars);

}
