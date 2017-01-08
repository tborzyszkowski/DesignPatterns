package facade.selling.facade;

import facade.selling.service1.Item1;
import facade.selling.service1.ROLE;
import facade.selling.service1.SellingService1Interface;
import facade.selling.service2.AuthorizationStatus;
import facade.selling.service2.AuthorizationCallback;
import facade.selling.service2.Item2;
import facade.selling.service2.SellingService2Interface;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;
import java.util.Set;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.ExecutionException;
import java.util.stream.Collectors;
import java.util.stream.Stream;

/**
 * Created by jakub on 1/1/17.
 */
public class SellingFacade {

    static SellingService1Interface sellingService1;

    static SellingService2Interface sellingService2;


    public static void main(String[] args) {
        init();
        SellingFacade sellingFacade = new SellingFacade();
        try {
            if(sellingFacade.login("test", "test")) {
                List<FacadeItem> car = sellingFacade.searchItems("car");
                sellingFacade.buyItems(car);
            } else {
                System.out.print("facade login failure");
            }
        } catch (ExecutionException e) {
            e.printStackTrace();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

    }

    public boolean login(String username, String password) throws ExecutionException, InterruptedException {
        CompletableFuture<AuthorizationStatus> waitAuth = new CompletableFuture<>();
        sellingService2.authorize(username, password, new AuthorizationCallback() {
            @Override
            public void authResult(AuthorizationStatus response_status) {
                waitAuth.complete(response_status);
            }
        });
        if(sellingService1.authorize(username, password, ROLE.USER) == 200 || waitAuth.get() == AuthorizationStatus.AUTHORIZED) {
            System.out.println("auth ok");
            return true;
        }
        return false;
    }

    public List<FacadeItem> searchItems(String itemName) {
        Stream<FacadeItem> item1Stream = sellingService1.searchItem(itemName).stream().map(item -> FacadeItem.facadeItemOf(item));
        Stream<FacadeItem> item2Stream = sellingService2.searchItem(itemName).stream().map(item -> FacadeItem.facadeItemOf(item));

        return Stream.concat(item1Stream, item2Stream).collect(Collectors.toList());
    }

    public void buyItems(List<FacadeItem> items) {
        Stream<Item1> item1Stream = items.stream().filter(item -> item.getRootClass().equals(Item1.class)).map(facadeItem -> new Item1(facadeItem.getName()));
        item1Stream.forEach(item -> sellingService1.buyItem(item));
        sellingService2.buyItem(items.stream().filter(item -> item.getRootClass().equals(Item2.class)).map(facadeItem -> new Item2(facadeItem.getName())).collect(Collectors.toList()));
    }


    private static void init() {
        sellingService1 = new SellingService1Interface() {
            @Override
            public int authorize(String Username, String password, ROLE role) {
                System.out.println(getClass() + " authorized");
                return 200;
            }

            @Override
            public Set<Item1> searchItem(String item) {
                Set<Item1> items = new HashSet<>();
                items.add(new Item1());
                items.add(new Item1());
                System.out.println(items.size() + " items from " + getClass());
                return items;
            }

            @Override
            public void buyItem(Item1 item) {
                System.out.println("buying : " + item.getName() + " from class " + item.getClass().getSimpleName());
            }
        };

        sellingService2 = new SellingService2Interface() {
            @Override
            public void authorize(String username, String password, AuthorizationCallback callback) {
                new Thread(() -> callback.authResult(AuthorizationStatus.AUTHORIZED)).start();
                System.out.println(getClass() + " authorized");
            }

            @Override
            public List<Item2> searchItem(String item) {
                LinkedList<Item2> items = new LinkedList<>();
                items.add(new Item2());
                items.add(new Item2());
                System.out.println(items.size() + " items from " + getClass());
                return items;
            }

            @Override
            public void buyItem(List<Item2> items) {
                items.forEach(item -> System.out.println("buying : " + item.getName() + " from class " + item.getClass().getSimpleName()));
            }
        };
    }
}
