package orders;

import car.utils.CarType;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.ToString;

@AllArgsConstructor
@Getter
@ToString
public class Order {
    private CarType carType;
    private String userName;
    private String showroomName;
}
