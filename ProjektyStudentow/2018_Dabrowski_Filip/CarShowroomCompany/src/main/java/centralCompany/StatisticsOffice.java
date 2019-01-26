package centralCompany;

import car.cars.Car;
import user.model.OldUser;
import user.model.User;

import java.util.ArrayList;
import java.util.List;

public class StatisticsOffice {

    CentralCompanyFacade centralCompanyFacade;

    List<OldUser> listOfOldUsers;

    List<User> listOfNewUsers;

    List<Car> listOfCars;

    public StatisticsOffice() {
        centralCompanyFacade = new CentralCompanyFacade();
        listOfOldUsers = new ArrayList();
        listOfNewUsers = new ArrayList();
        listOfCars = new ArrayList();

        listOfOldUsers = centralCompanyFacade.downloadAllOldUsers();
        listOfNewUsers = centralCompanyFacade.downloadAllNormalUsers();

        listOfCars = centralCompanyFacade.downloadAllBoughtCars(listOfOldUsers, listOfNewUsers);
    }

    public void presentAllClients() {
        for (OldUser user: listOfOldUsers) {
            System.out.println( user.toString());
            System.out.println("\n");
        }
        for (User user: listOfNewUsers) {
            System.out.println(user.toString());
            System.out.println("\n");
        }
    }

    public void presentAllCars() {
        for (Car car: listOfCars) {
            System.out.println(car.toString());
            System.out.println("\n");
        }
    }


}
