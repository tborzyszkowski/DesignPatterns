import car.cars.Car;
import car.utils.CarType;
import centralCompany.CentralCompany;
import centralCompany.StatisticsOffice;
import orders.DoneOrder;
import orders.Order;
import org.junit.Before;
import org.junit.Test;
import showrooms.Showroom;
import user.UserType;
import user.adapters.OldUserAdapter;
import user.builder.UserBuilder;
import user.model.IOldUser;
import user.model.IUser;
import user.model.OldUser;
import user.model.User;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class ApplicationTests {

    CentralCompany centralCompany;

    Showroom gdanskShowroom;

    Showroom warszawaShowroom;

    Showroom katowiceShowRoom;


    @Before
    public void prepareData() {
        centralCompany = CentralCompany.getInstance();

        createShowrooms();

        centralCompany.addNewShowroom(gdanskShowroom);
        centralCompany.addNewShowroom(warszawaShowroom);
        centralCompany.addNewShowroom(katowiceShowRoom);

    }

    @Test
    public void should_order_sport_car_for_new_user_bernadetta_kowalska() {
        IUser client = (IUser) gdanskShowroom.getUserManager().getUser("Bernadetta Kowalska");
        gdanskShowroom.getCarDealer().orderCar(CarType.SPORTS_CAR, client.getUserName(), gdanskShowroom.getShowroomName());

        Order order = centralCompany.getOrderList().stream()
                .filter(item -> item.getUserName().equals("Bernadetta Kowalska"))
                .findFirst().orElse(null);

        System.out.println(order.toString());
    }

    @Test
    public void should_build_ordered_car() {
        IUser client = (IUser) gdanskShowroom.getUserManager().getUser("Bernadetta Kowalska");
        gdanskShowroom.getCarDealer().orderCar(CarType.SPORTS_CAR, client.getUserName(), gdanskShowroom.getShowroomName());
        centralCompany.produceAllCars();

        List<DoneOrder> doneOrders = centralCompany.getAvailableCarsList();
        doneOrders.stream().forEach(car -> System.out.println(car.toString()));

    }

    @Test
    public void should_get_car_from_central_company() {

        IUser client = (IUser) gdanskShowroom.getUserManager().getUser("Bernadetta Kowalska");
        IUser client2 = (IUser) katowiceShowRoom.getUserManager().getUser("Romek Siemiatkowski");
        IOldUser client3 = (IOldUser) warszawaShowroom.getUserManager().getUser("Gabrys");

        gdanskShowroom.getCarDealer().orderCar(CarType.SPORTS_CAR, client.getUserName(), gdanskShowroom.getShowroomName());
        katowiceShowRoom.getCarDealer().orderCar(CarType.SUV, client2.getUserName(), katowiceShowRoom.getShowroomName());
        warszawaShowroom.getCarDealer().orderCar(CarType.LIMO, client3.getSecondName(), warszawaShowroom.getShowroomName());
        warszawaShowroom.getCarDealer().orderCar(CarType.SEDAN, client3.getSecondName(), warszawaShowroom.getShowroomName());

        centralCompany.produceAllCars();
        centralCompany.informAboutNewCars();

        System.out.println("Bernadetta Kowalska: ");
        System.out.println(((IUser) gdanskShowroom.getUserManager()
                .getUser("Bernadetta Kowalska"))
                .getBoughtCars()
                .toString());
        System.out.println("\n");

        System.out.println("Romek Siemiatkowski: ");
        System.out.println(((IUser) katowiceShowRoom.getUserManager()
                .getUser("Romek Siemiatkowski"))
                .getBoughtCars()
                .toString());
        System.out.println("\n");

        System.out.println("Jan Gabrys: ");
        System.out.println(Arrays.toString(
                ((IOldUser) warszawaShowroom.getUserManager()
                        .getUser("Gabrys"))
                        .getBoughtCars()));

    }

    @Test
    public void should_move_client_from_warsaw_to_gdansk() {

        IOldUser oldUser = (IOldUser) warszawaShowroom.getUserManager().getUser("Gabrys");

        warszawaShowroom.getCarDealer().orderCar(CarType.HATCH_BAG, oldUser.getSecondName(), warszawaShowroom.getShowroomName());
        warszawaShowroom.getCarDealer().orderCar(CarType.SPORTS_CAR, oldUser.getSecondName(), warszawaShowroom.getShowroomName());

        centralCompany.produceAllCars();
        centralCompany.informAboutNewCars();

        OldUserAdapter oldUserAdapter = new OldUserAdapter(oldUser);

        IUser newUser = new UserBuilder()
                .withUserName(oldUserAdapter.getUserName())
                .withAddress(oldUserAdapter.getAddress())
                .withAge(oldUserAdapter.getAge())
                .withEmail(oldUserAdapter.getEmail())
                .withPhoneNumber(oldUserAdapter.getPhoneNumber())
                .withBoughtCars(oldUserAdapter.getBoughtCars())
                .buildUser();

        gdanskShowroom.getUserManager().addUser(newUser);

        IUser newGdanskUser = (IUser) gdanskShowroom.getUserManager().getUser("Jan Gabrys");

        gdanskShowroom.getCarDealer().orderCar(CarType.SUV, newGdanskUser.getUserName(), gdanskShowroom.getShowroomName());

        centralCompany.produceAllCars();
        centralCompany.informAboutNewCars();

        System.out.println("Jan Gabrys: ");
        ((IUser) gdanskShowroom.getUserManager()
                .getUser("Jan Gabrys"))
                .getBoughtCars()
                .forEach( car -> {
                    System.out.println(car.toString());
                    System.out.println("\n");
                });


    }

    @Test
    public void should_share_data_with_statistics_office() {

        IUser client = (IUser) gdanskShowroom.getUserManager().getUser("Bernadetta Kowalska");
        IUser client2 = (IUser) katowiceShowRoom.getUserManager().getUser("Romek Siemiatkowski");
        IOldUser client3 = (IOldUser) warszawaShowroom.getUserManager().getUser("Gabrys");

        gdanskShowroom.getCarDealer().orderCar(CarType.SPORTS_CAR, client.getUserName(), gdanskShowroom.getShowroomName());
        gdanskShowroom.getCarDealer().orderCar(CarType.HATCH_BAG, client.getUserName(), gdanskShowroom.getShowroomName());

        katowiceShowRoom.getCarDealer().orderCar(CarType.SUV, client2.getUserName(), katowiceShowRoom.getShowroomName());

        warszawaShowroom.getCarDealer().orderCar(CarType.LIMO, client3.getSecondName(), warszawaShowroom.getShowroomName());
        warszawaShowroom.getCarDealer().orderCar(CarType.SEDAN, client3.getSecondName(), warszawaShowroom.getShowroomName());

        centralCompany.produceAllCars();
        centralCompany.informAboutNewCars();

        StatisticsOffice statisticsOffice = new StatisticsOffice();

        System.out.println("Clients: ");
        statisticsOffice.presentAllClients();
        System.out.println("\n");
        System.out.println("Cars: ");
        statisticsOffice.presentAllCars();
    }

    private void createShowrooms() {
        prepareGdanskShowroom();
        prepareKatowiceShowroom();
        prepareWarszawaShowroom();
    }

    private void prepareGdanskShowroom() {
        gdanskShowroom = new Showroom("gdanskShowroom", UserType.NORMAL);

        User bernadettaKowalska = new UserBuilder()
                .withUserName("Bernadetta Kowalska")
                .withAge(61)
                .withAddress("Jana Nowaka 32")
                .withEmail("jane@osd.ds")
                .withPhoneNumber(123123123)
                .withBoughtCars(new ArrayList())
                .buildUser();

        gdanskShowroom.getUserManager().addUser(bernadettaKowalska);
    }

    private void prepareWarszawaShowroom() {
        warszawaShowroom = new Showroom("warszawaShowroom", UserType.OLD);

        OldUser janeKowalska = new OldUser(
                "Jane",
                "Kowalska",
                42,
                "Jana Nowaka 32",
                "jane@osd.ds",
                123123123,
                new Car[100]
        );

        OldUser jacekNowak = new OldUser(
                "Jacek",
                "Nowak",
                22,
                "Jana Kosza 2",
                "jacek@osd.ds",
                123123113,
                new Car[100]
        );

        OldUser janGabrys = new OldUser(
                "Jan",
                "Gabrys",
                49,
                "Mirowa 2",
                "jan@osd.ds",
                123523113,
                new Car[100]
        );

        warszawaShowroom.getUserManager().addUser(janeKowalska);
        warszawaShowroom.getUserManager().addUser(jacekNowak);
        warszawaShowroom.getUserManager().addUser(janGabrys);

    }

    private void prepareKatowiceShowroom() {
        katowiceShowRoom = new Showroom("katowiceShowroom", UserType.NORMAL);

        User mirasJarzabek = new UserBuilder()
                .withUserName("Miras Jarzabek")
                .withAge(22)
                .withAddress("Powile 56")
                .withEmail("mirek@osd.ds")
                .withBoughtCars(new ArrayList())
                .buildUser();

        User zuzaKochanowska = new UserBuilder()
                .withUserName("Zuza Kochanowska")
                .withAge(41)
                .withAddress("Kopernika 2")
                .withPhoneNumber(793123123)
                .withBoughtCars(new ArrayList())
                .buildUser();

        User romekSiemiatkowski = new UserBuilder()
                .withUserName("Romek Siemiatkowski")
                .withAge(91)
                .withAddress("Kielecka 3")
                .withEmail("jane@osd.ds")
                .withPhoneNumber(123123123)
                .withBoughtCars(new ArrayList())
                .buildUser();

        katowiceShowRoom.getUserManager().addUser(mirasJarzabek);
        katowiceShowRoom.getUserManager().addUser(zuzaKochanowska);
        katowiceShowRoom.getUserManager().addUser(romekSiemiatkowski);
    }

}
