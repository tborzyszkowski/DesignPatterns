package user.userManagers;

import car.cars.Car;
import user.model.IUser;

import java.util.ArrayList;
import java.util.List;

public class UserManager implements IUserManager<IUser> {

    private List<IUser> userList;

    public UserManager() {
        this.userList = new ArrayList();
    }

    @Override
    public void addUser(IUser user) {
        this.userList.add(user);
    }

    @Override
    public List<IUser> getAllUser() {
        return userList;
    }

    @Override
    public IUser getUser(String userName) {
        IUser user = userList.stream()
                .filter( filteredUser -> filteredUser.getUserName().equals(userName))
                .findFirst()
                .orElse(null);
        return user;
    }

    @Override
    public void updateUser(String username, Car car) {
        getUser(username).getBoughtCars().add(car);
    }

}
