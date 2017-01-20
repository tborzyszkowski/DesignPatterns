package engine;

import figure.Figure;
import lombok.Builder;
import lombok.Getter;

/**
 * Created by jakub on 1/18/17.
 */
@Builder
@Getter
public class AreaResult {
    private Figure figure;
    private Double result;

    @Override
    public String toString() {
        return "pole figury: " + figure.toString() + " wyniosło " + result;
    }
}
