package queue;
import java.util.ArrayList;
import java.util.Iterator;

public class Queue implements QueueInterface {

    ArrayList<QueueChecker> observers;
    int queueSize;

    public Queue(){
        observers = new ArrayList<>();
        this.queueSize = 0;
    }

    @Override
    public void addObserver(QueueChecker qc) {
        observers.add(qc);
    }

    @Override
    public void removeObserver(QueueChecker qc) {
        observers.remove(qc);
    }

    @Override
    public void notifyObservers() {
        Iterator<QueueChecker> it = observers.iterator();
        while (it.hasNext()){
            QueueChecker qc = (QueueChecker) it.next();
            qc.update(queueSize);
        }
    }

    public void newClientCame(){
        queueSize += 1;
        notifyObservers();
    }

    public void clientLeft(){
        queueSize -= 1;
        notifyObservers();
    }
}
