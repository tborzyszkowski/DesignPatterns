package orders;

import car.cars.Car;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.ToString;

@AllArgsConstructor
@Getter
@ToString
public class DoneOrder {
    private Car car;
    private String userName;
    private String showroomName;
}
