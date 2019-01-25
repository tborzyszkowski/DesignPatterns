package queue;

public interface QueueInterface {
    void addObserver(QueueChecker qc);
    void removeObserver(QueueChecker qc);
    void notifyObservers();
}
