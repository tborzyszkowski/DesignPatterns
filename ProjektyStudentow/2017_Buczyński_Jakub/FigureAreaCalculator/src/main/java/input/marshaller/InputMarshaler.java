package input.marshaller;

import rx.Observer;
import rx.Subscription;

/**
 * Created by jakub on 1/22/17.
 */
public interface InputMarshaler {
    public void parseInput(String inputLine);

    public Subscription subscribeInput(Observer observer);
}
