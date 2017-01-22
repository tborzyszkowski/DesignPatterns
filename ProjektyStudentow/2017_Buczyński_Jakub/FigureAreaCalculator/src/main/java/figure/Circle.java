package figure;

import lombok.Builder;

import static java.lang.Math.PI;

/**
 * Created by jakub on 1/16/17.
 */
@Builder
public class Circle extends Figure {
    private double radius;
    private double pi = Math.PI;

    @Override
    public double computeArea() {
        return Math.PI * radius * radius;
    }

    @Override
    public String toString() {
        return " okrąg o promieniu " +radius ;
    }
}
