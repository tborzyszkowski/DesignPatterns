package builder;

public class VehicleConstructor {

    public Vehicle buildMotorCycle() {

        return constructVehicle("motorcycle", "motorcycle frame",
                "1 litre", "2", "no doors");
    }

    public Vehicle buildCar() {

        return constructVehicle("car", "car frame",
                "6 litre", "4", "3 doors");
    }

    public Vehicle buildScooter() {

        return constructVehicle("scooter", "funny frame",
                "0.2 litre", "2", "no doors");
    }

    private Vehicle constructVehicle
            (String vehicleType, String frame, String engine,
             String wheels, String doors) {

        return Vehicle.builder()
                .vehicleType(vehicleType).frame(frame).engine(engine)
                .wheels(wheels).doors(doors).build();
    }
}
