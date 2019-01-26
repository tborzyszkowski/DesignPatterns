package user.userManagers;

import car.cars.Car;
import user.model.IOldUser;

import java.util.ArrayList;
import java.util.List;

public class OldUserManager implements IUserManager<IOldUser> {

    private List<IOldUser> oldUserList;

    public OldUserManager() {
        this.oldUserList = new ArrayList();
    }

    @Override
    public void addUser(IOldUser user) {
        this.oldUserList.add(user);
    }

    @Override
    public List<IOldUser> getAllUser() {
        return oldUserList;
    }

    @Override
    public IOldUser getUser(String secondName) {
        return oldUserList.stream()
                .filter(user -> user.getSecondName().equals(secondName))
                .findFirst()
                .orElse(null);
    }

    @Override
    public void updateUser(String username, Car car) {
        Car[] list = getUser(username).getBoughtCars();
        for(int i = 0 ; i < list.length ; i++ ){
            if(list[i] == null) {
                list[i] = car;
                break;
            }
        }
    }

}
