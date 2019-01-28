package toolShop;
import queue.Client;
import queue.Queue;
import queue.QueueChecker;
import shoppingList.AbstractShoppingList;
import shoppingList.DiscountDecorator;
import shoppingList.NewProductDecorator;
import shoppingList.ShoppingList;
import tools.Tool;
import tools.ToolBuilder;

import java.util.ArrayList;
import java.util.List;

public class ToolShopFacade {
    private ToolBuilder toolBuilder1;
    private ToolBuilder toolBuilder2;
    private ToolBuilder toolBuilder3;
    private ToolShop toolShop;
    private ArrayList<Tool> toolsList;
    private AbstractShoppingList list;
    private Client client;

    public ToolShopFacade() {
        this.toolShop = ToolShop.getInstance();
    }

    public void buildTools(){
        this.toolBuilder1 = new ToolBuilder();
        this.toolBuilder2 = new ToolBuilder();
        this.toolBuilder3 = new ToolBuilder();

        Tool tool = toolBuilder1
                .withBrand("Neo")
                .withModel("08-254")
                .withName("Metal case")
                .withType("Boxes")
                .withPrice(20)
                .withQuantity(1)
                .buildTool();

        toolShop.addToolToToolShop(tool);

        tool = toolBuilder2
                .withBrand("Graphite")
                .withModel("59G207")
                .withName("Angle grinder")
                .withType("PowerTools")
                .withPower(2350)
                .withPrice(300)
                .buildTool();

        toolShop.addToolToToolShop(tool);

        tool = toolBuilder3
                .withBrand("Walmer")
                .withModel("MGM800")
                .withName("Tile cutting machine")
                .withType("Hand tools")
                .withPower(0)
                .withPrice(249)
                .withQuantity(2)
                .buildTool();

        toolShop.addToolToToolShop(tool);
    }

    public ArrayList<Tool> getToolsList(){
        toolsList = new ArrayList<Tool>();
        toolsList = ToolShop.getToolsList();
        return toolsList;
    }

    public Queue generateQueue(){
        Queue queue = new Queue();
        return queue;
    }

    public QueueChecker generateQueueChecker(){
        QueueChecker qc = new QueueChecker(1);
        return qc;
    }

    public void newClient(Queue queue, QueueChecker qc){
        client = new Client();
        client.newClient(queue);
    }

    public void addObserverToQueue(Queue queue, QueueChecker qc){
        client.addObserver(queue, qc);
    }
    public void clientLeft(Queue queue){
        client.clientLeft(queue);

    }

    public ArrayList<AbstractShoppingList> generateShoppingList(){
        List<AbstractShoppingList> shoppingList = new ArrayList<>();
        list = new ShoppingList();
        shoppingList.add(list);
        return list;
        }

    public ArrayList<AbstractShoppingList> addToolToShoppingList(String toolname){
        list = new NewProductDecorator(list, toolShop.getToolFromToolsList(toolname));
        return list;
    }

    public ArrayList<AbstractShoppingList> decorateDiscount(int percent){
        list = new DiscountDecorator(list, percent);
        return list;
    }
}
