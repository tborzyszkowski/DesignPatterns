package queue;

public class QueueChecker {
    private int observerNumber;

    public QueueChecker(int observerNumber){
        this.observerNumber = observerNumber;
    }

    public void update(int queueSize){
        System.out.println("Queue size has changed to: " + queueSize);
    }
}
