package facade.selling.service1;

import java.util.Set;

/**
 * Created by jakub on 1/1/17.
 */
public interface SellingService1Interface {
    public int authorize(String Username, String password, ROLE role);
    public Set<Item1> searchItem(String item);
    public void buyItem(Item1 item);
}
