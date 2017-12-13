package builder;

import lombok.Builder;
import lombok.Value;

@Value
@Builder
public class Vehicle {
    String vehicleType;
    String frame;
    String engine;
    String wheels;
    String doors;
}