package centralCompany;

import car.cars.Car;
import car.fabricMethodsFactories.CarFactory;
import car.fabricMethodsFactories.FordFactory;
import car.utils.CarType;
import lombok.Getter;
import orders.DoneOrder;
import orders.Order;
import showrooms.Showroom;

import java.util.ArrayList;
import java.util.List;

@Getter
public class CentralCompany {

    private static CentralCompany centralCompany;

    private List<Showroom> showroomList;

    private List<Order> orderList;

    private List<DoneOrder> availableCarsList;

    private CarFactory fordFactory;

    private CentralCompany() {
        this.showroomList = new ArrayList();
        this.orderList = new ArrayList();
        this.availableCarsList = new ArrayList();
        this.fordFactory = new FordFactory();
    }

    public static CentralCompany getInstance() {
        if (centralCompany == null) {
            centralCompany = new CentralCompany();
        }
        return centralCompany;
    }

    public void addNewShowroom(Showroom showroom) {
        showroomList.add(showroom);
    }

    public Showroom getShowroomFromList(String showroomName) {
        return showroomList.stream()
                .filter( showroom -> showroom.getShowroomName().equals(showroomName))
                .findFirst()
                .orElse(null);
    }

    public void informAboutNewCars() {
        showroomList.stream().forEach( showroom -> showroom.getNewCars(availableCarsList));
        availableCarsList = new ArrayList();
    }

    public void produceAllCars() {
        orderList.stream()
                .forEach((order) -> {
                    Car car = fordFactory.orderCar(order.getCarType());
                    availableCarsList.add(new DoneOrder(car, order.getUserName(), order.getShowroomName()));
                });
        orderList = new ArrayList();
    }

    public void addCarToOrderList(CarType carType, String userName, String showroomName) {
        orderList.add(new Order(carType, userName, showroomName));
    }

}
