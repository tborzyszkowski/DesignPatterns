package user.adapters;

import car.cars.Car;
import user.model.IOldUser;
import user.model.IUser;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class OldUserAdapter implements IUser {

    IOldUser oldUser;

    public OldUserAdapter(IOldUser oldUser) {
        this.oldUser = oldUser;
    }

    @Override
    public String getUserName() {
        return oldUser.getFirstName() + " "+oldUser.getSecondName();
    }

    @Override
    public int getAge() {
        return oldUser.getAge();
    }

    @Override
    public String getAddress() {
        return oldUser.getAddress();
    }

    @Override
    public String getEmail() {
        return oldUser.getEmail();
    }

    @Override
    public int getPhoneNumber() {
        return oldUser.getPhoneNumber();
    }

    @Override
    public List<Car> getBoughtCars() {
        List<Car> carList =  new ArrayList<>(Arrays.asList(oldUser.getBoughtCars()));
        return carList.stream().filter(item -> item != null).collect(Collectors.toList());
    }

}
