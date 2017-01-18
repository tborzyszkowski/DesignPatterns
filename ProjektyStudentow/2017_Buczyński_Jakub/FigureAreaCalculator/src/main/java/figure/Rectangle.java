package figure;

import lombok.Builder;

/**
 * Created by jakub on 1/16/17.
 */
@Builder
public class Rectangle extends Figure {
    private double sideA;
    private double sideB;

    @Override
    public double computeArea() {
        return sideA * sideB;
    }

    @Override
    public String toString() {
        return " prostokąt o bokach A " + sideA + " B " + sideB;
    }
}
