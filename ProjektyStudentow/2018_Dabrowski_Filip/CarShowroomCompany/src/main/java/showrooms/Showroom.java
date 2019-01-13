package showrooms;

import lombok.Getter;
import orders.DoneOrder;
import user.UserType;
import user.userManagers.IUserManager;
import user.userManagers.OldUserManager;
import user.userManagers.UserManager;

import java.util.List;

@Getter
public class Showroom {

    private String showroomName;

    private CarDealer carDealer;

    private IUserManager userManager;

    private UserType typeOfUsers;

    public Showroom(String name, UserType usersType) {
        this.showroomName = name;
        this.typeOfUsers = usersType;
        this.carDealer = new CarDealer();
        if (usersType == UserType.NORMAL) {
            userManager = new UserManager();
        } else if (usersType == UserType.OLD) {
            userManager = new OldUserManager();
        }
    }

    public void getNewCars(List<DoneOrder> doneOrderList) {
        doneOrderList.stream()
                .filter(order -> order.getShowroomName().equals(showroomName))
                .forEach( order -> {
                    userManager.updateUser(order.getUserName(), order.getCar());
                });
    }
}
