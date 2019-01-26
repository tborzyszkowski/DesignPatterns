package user.userManagers;

import car.cars.Car;

import java.util.List;

public interface IUserManager<A> {

    public void addUser(A user);
    public List<A> getAllUser();
    public A getUser(String value);
    public void updateUser(String username, Car car);

}
