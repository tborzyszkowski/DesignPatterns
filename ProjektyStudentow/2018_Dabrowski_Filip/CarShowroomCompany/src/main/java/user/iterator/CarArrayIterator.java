package user.iterator;

import car.cars.Car;

public class CarArrayIterator implements CarIterator {

    Car [] boughtCars;
    int position = 0;

    public CarArrayIterator(Car[] boughtCars) {
        this.boughtCars = boughtCars;
    }

    @Override
    public boolean hasNext() {
        if(position >= boughtCars.length || boughtCars[position] == null ) {
            return false;
        } else {
            return true;
        }
    }

    @Override
    public Car next() {
        Car car = boughtCars[position];
        position++;
        return car;
    }
}