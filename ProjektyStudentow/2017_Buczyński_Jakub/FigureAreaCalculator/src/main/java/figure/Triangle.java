package figure;

import lombok.Builder;

import java.util.Optional;

/**
 * Created by jakub on 1/16/17.
 */
@Builder
public class Triangle extends Figure {
    private double sideA;
    private double sideB;
    private double sideC;
    private Double height;

    @Override
    public double computeArea() {
        return Optional.ofNullable(height).isPresent() ? computeWhenHeightIsGiven() : computeWhenNoHeightGiven();
    }

    private double computeWhenNoHeightGiven() {
        double p = (sideA + sideB + sideC) / 2;
        return Math.sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
    }

    private double computeWhenHeightIsGiven() {
        return sideA * height;
    }

    @Override
    public String toString() {
        return " trójkąt o bokach A " + sideA + " B " + sideB + " C " + sideC + " i wysokosci " + height;
    }
}
