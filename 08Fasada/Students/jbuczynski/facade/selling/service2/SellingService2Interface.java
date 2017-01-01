package facade.selling.service2;

import java.util.List;

/**
 * Created by jakub on 1/1/17.
 */
public interface SellingService2Interface {
    public void authorize(String username, String password, AuthorizationCallback callback);
    public List<Item2> searchItem(String item);
    public void buyItem(List<Item2> items);
}
