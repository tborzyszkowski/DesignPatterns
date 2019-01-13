package user.adapters;

import car.cars.Car;
import user.model.IOldUser;
import user.model.IUser;

public class UserAdapter implements IOldUser {

    private IUser user;

    public UserAdapter(IUser user) {
        this.user = user;
    }

    @Override
    public String getFirstName() {
        String[] nameList = user.getUserName().split(" ");
        return nameList[0];
    }

    @Override
    public String getSecondName() {
        String[] nameList = user.getUserName().split(" ");
        return nameList[1];
    }

    @Override
    public int getAge() {
        return user.getAge();
    }

    @Override
    public String getAddress() {
        return user.getAddress();
    }

    @Override
    public String getEmail() {
        return user.getEmail();
    }

    @Override
    public int getPhoneNumber() {
        return user.getPhoneNumber();
    }

    @Override
    public Car[] getBoughtCars() {
        return user.getBoughtCars().stream().toArray(Car[]::new);
    }

    @Override
    public void setBoughtCars(Car[] boughtCars) {

    }
}
