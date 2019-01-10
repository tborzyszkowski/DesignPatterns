import car.cars.Car;
import car.fabricMethodsFactories.FordFactory;
import car.utils.CarType;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import user.adapters.OldUserAdapter;
import user.adapters.UserAdapter;
import user.builder.UserBuilder;
import user.model.IOldUser;
import user.model.IUser;
import user.model.OldUser;

import java.util.ArrayList;
import java.util.List;

public class UsersAdapterTest {

    OldUserAdapter oldUserAdapter;
    UserAdapter userAdapter;

    IOldUser oldUser;
    IUser user;

    FordFactory fordFactory;
    Car sportsCar;
    Car suvCar;

    @Before
    public void prepareTests() {
        fordFactory = FordFactory.getInstance();
        sportsCar = fordFactory.orderCar(CarType.SPORTS_CAR);
        suvCar = fordFactory.orderCar(CarType.SUV);
        prepareOldUser();
        prepareUser();

    }

    @Test
    public void should_convert_old_user_to_user() {
        oldUserAdapter = new OldUserAdapter(oldUser);
        Assert.assertEquals(oldUserAdapter.getBoughtCars(), user.getBoughtCars());
        Assert.assertEquals(oldUserAdapter.getUserName(), user.getUserName());
    }

    @Test
    public void should_convert_user_to_old_user() {
        userAdapter = new UserAdapter(user);
        Assert.assertEquals(oldUser.getFirstName(), userAdapter.getFirstName());
        Assert.assertEquals(oldUser.getSecondName(), userAdapter.getSecondName());
        Assert.assertEquals(oldUser.getBoughtCars(), userAdapter.getBoughtCars());
    }

    private void prepareOldUser() {
        Car[] cars = new Car[2];
        cars[0] = sportsCar;
        cars[1] = suvCar;

        this.oldUser = new OldUser(
                "Jane",
                "Kowalska",
                2,
                "Jana Nowaka 32",
                "jane@osd.ds",
                123123123,
                cars
        );
    }

    private void prepareUser() {
        List<Car> carList = new ArrayList();
        carList.add(sportsCar);
        carList.add(suvCar);

        UserBuilder userBuilder = new UserBuilder();

        this.user = userBuilder
                .withUserName("Jane Kowalska")
                .withAge(2)
                .withAddress("Jana Nowaka 32")
                .withEmail("jane@osd.ds")
                .withPhoneNumber(123123123)
                .withBoughtCars(carList)
                .buildUser();
    }

}
