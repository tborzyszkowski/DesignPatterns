package queue;

public class Client {

    public void addObserver(Queue queue, QueueChecker qc){
        queue.addObserver(qc);
    }

    public void newClient(Queue queue){
        System.out.println("New client came");
        queue.newClientCame();
    }

    public void clientLeft(Queue queue){
        System.out.println("Client has left");
        queue.clientLeft();
    }
}
