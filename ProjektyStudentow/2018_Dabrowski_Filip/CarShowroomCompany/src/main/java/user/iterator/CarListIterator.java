package user.iterator;

import car.cars.Car;

import java.util.List;

public class CarListIterator implements CarIterator {

    List<Car> boughtCars;
    int position = 0;

    public CarListIterator(List<Car> boughtCars) {
        this.boughtCars = boughtCars;
    }

    @Override
    public boolean hasNext() {
        if (position >= boughtCars.size() || boughtCars.get(position)== null) {
            return false;
        } else {
            return true;
        }

    }

    @Override
    public Car next() {
        Car car = boughtCars.get(position);
        position++;
        return car;
    }
}
