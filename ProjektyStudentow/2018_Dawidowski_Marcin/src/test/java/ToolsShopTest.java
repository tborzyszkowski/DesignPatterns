import org.junit.Before;
import org.junit.Test;
import queue.Queue;
import queue.QueueChecker;
import shoppingList.AbstractShoppingList;
import toolShop.ToolShopFacade;
import java.util.ArrayList;

public class ToolsShopTest {
    private ToolShopFacade toolShop;
    private Queue queue;
    private QueueChecker queueChecker;
    private ArrayList<AbstractShoppingList> list;
    @Before
    public void create_tools_shop(){
        toolShop = new ToolShopFacade();
    }

    @Test
    public void start_tools_shop(){
        toolShop.buildTools();
        System.out.println(toolShop.getToolsList());

        queue = toolShop.generateQueue();
        queueChecker = toolShop.generateQueueChecker();
        toolShop.newClient(queue, queueChecker);
        toolShop.addObserverToQueue(queue, queueChecker);
        list = toolShop.generateShoppingList();

        list = toolShop.addToolToShoppingList("Walmer");
        list = toolShop.addToolToShoppingList("Graphite");
        System.out.println(list);

        list = toolShop.decorateDiscount(10);
        System.out.println(list);

        toolShop.clientLeft(queue);
        toolShop.newClient(queue, queueChecker);
    }
}
