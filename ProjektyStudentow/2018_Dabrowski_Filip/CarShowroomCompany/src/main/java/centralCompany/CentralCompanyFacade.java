package centralCompany;

import car.cars.Car;
import user.UserType;
import user.iterator.CarIterator;
import user.model.OldUser;
import user.model.User;

import java.util.ArrayList;
import java.util.List;

public class CentralCompanyFacade {

    private CentralCompany centralCompany;

    public CentralCompanyFacade() {
        this.centralCompany = CentralCompany.getInstance();
    }

    public List<User> downloadAllNormalUsers() {
        List<User> allNormalUsers = new ArrayList();
        centralCompany.getShowroomList().stream().
                forEach(showroom -> {
                    if(showroom.getTypeOfUsers() == UserType.NORMAL) {
                        allNormalUsers.addAll(showroom.getUserManager().getAllUser());
                    }
                });

        return allNormalUsers;
    }

    public List<OldUser> downloadAllOldUsers() {
        List<OldUser> allOldUsers = new ArrayList();
        centralCompany.getShowroomList().stream().
                forEach(showroom -> {
                    if(showroom.getTypeOfUsers() == UserType.OLD) {
                        allOldUsers.addAll(showroom.getUserManager().getAllUser());
                    }
                });

        return allOldUsers;
    }

    public List<Car> downloadAllBoughtCars(List<OldUser> allOldUsers, List<User> allNormalUsers) {
        List<Car> carList = new ArrayList();
        getAllCarsIterator().stream()
                .forEach( (iterator) -> {
                    while(iterator.hasNext()){
                        carList.add(iterator.next());
                    }
                });
        return carList;
    }

    private List<CarIterator> getAllCarsIterator() {
        List<CarIterator> carIterators = new ArrayList();
        downloadAllNormalUsers().stream().forEach(user -> carIterators.add(user.createIterator()));
        downloadAllOldUsers().stream().forEach( user -> carIterators.add(user.createIterator()));
        return carIterators;
    }

}
