package showrooms;

import car.utils.CarType;
import centralCompany.CentralCompany;
import lombok.Data;

@Data
public class CarDealer {

    private CentralCompany centralCompany;

    public CarDealer() {
        centralCompany = CentralCompany.getInstance();
    }

    public void orderCar(CarType carType, String userName, String showroomName) {
        centralCompany.addCarToOrderList(carType, userName, showroomName);
    }

}
