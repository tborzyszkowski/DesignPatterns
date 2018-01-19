package design.patterns;

import design.patterns.client.Client;
import design.patterns.client.ClientBuilder;
import design.patterns.client.Color;
import design.patterns.copy.XeroCopy;
import design.patterns.facade.XeroFacade;
import design.patterns.observer.Observer;
import design.patterns.printers.Printer;
import design.patterns.printers.builder.PrinterBuilder;
import design.patterns.printers.state.BusyState;
import design.patterns.singleton.SuppliesSingleton;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class Main {

    public static void main(String[] args) {
        XeroFacade xeroFacade = new XeroFacade();
        List<Client> clients = getClients();
        List<Printer> printers = createPrinters();
        SuppliesSingleton instance = SuppliesSingleton.getInstance();
        instance.addAllSupplies(5, 5, printers, 10000);
        clients.stream().parallel().forEach(c -> orderCopy(c, xeroFacade));
    }

    private static void orderCopy(Client client, XeroFacade xeroFacade) {
        prepareSysOut("Name: " + client.getId());
        //znalezienie wolnej drukarki do naszego zadania (kolor) i oddelegowanie prośby o wydruk do fasady
        SuppliesSingleton instance = SuppliesSingleton.getInstance();
        Printer printer = null;
        while (printer == null) {
            printer = instance.findFirstNotBusyForColor(client.getColor());
        }
        BusyState busyState = new BusyState();
        busyState.doAction(printer);
        prepareSysOut("Printer found: " + printer.getId());
        XeroCopy copy = xeroFacade.createCopy(printer, client);

        //zwolnienie drukarki
        printer.setState(null);
        prepareSysOut("End copy for client: " + client.getId());
        prepareSysOut(copy.toString());
    }

    private static List<Printer> createPrinters() {
        PrinterBuilder printerBuilder = new PrinterBuilder();
        List<Printer> printers = new ArrayList<>();
        Printer printerFirst = printerBuilder.newInstance().setBlackInk(Constants.MAX_PAGES_BLACK_INK).setColorInk(Constants.MAX_PAGES_COLOR_INK)
                .setOnlyBlack(true).setPaper(2600).setId(UUID.randomUUID()).setMaxPaper(2600).build();
        new Observer(printerFirst);
        printers.add(printerFirst);

        Printer printerSecond = printerBuilder.newInstance().setBlackInk(Constants.MAX_PAGES_BLACK_INK).setColorInk(Constants.MAX_PAGES_COLOR_INK)
                .setOnlyBlack(false).setPaper(7000).setId(UUID.randomUUID()).setMaxPaper(7000).build();
        new Observer(printerSecond);
        printers.add(printerSecond);

        Printer printerThird = printerBuilder.newInstance().setBlackInk(Constants.MAX_PAGES_BLACK_INK).setColorInk(Constants.MAX_PAGES_COLOR_INK)
                .setOnlyBlack(false).setPaper(550).setId(UUID.randomUUID()).setMaxPaper(550).build();
        new Observer(printerThird);
        printers.add(printerThird);

        Printer printerFourth = printerBuilder.newInstance().setBlackInk(Constants.MAX_PAGES_BLACK_INK).setOnlyBlack(true)
                .setColorInk(Constants.MAX_PAGES_COLOR_INK).setPaper(2600).setId(UUID.randomUUID()).setMaxPaper(2600).build();
        new Observer(printerFourth);
        printers.add(printerFourth);
        return printers;
    }

    private static List<Client> getClients() {
        ClientBuilder clientBuilder = new ClientBuilder();
        List<Client> clients = new ArrayList<>();
        clients.add(clientBuilder.newInstance().setName("Client1").setSurname("").setId(UUID.randomUUID())
                .setPages(100).setColor(Color.BLACK_WHITE).build());

        clients.add(clientBuilder.newInstance().setName("Client2").setSurname("").setId(UUID.randomUUID())
                .setPages(25).setColor(Color.COLOR).build());

        clients.add(clientBuilder.newInstance().setName("Client3").setSurname("").setId(UUID.randomUUID())
                .setPages(50).setColor(Color.COLOR).build());

        clients.add(clientBuilder.newInstance().setName("Client4").setSurname("").setId(UUID.randomUUID())
                .setPages(1000).setColor(Color.BLACK_WHITE).build());

        clients.add(clientBuilder.newInstance().setName("Client5").setSurname("").setId(UUID.randomUUID())
                .setPages(100).setColor(Color.BLACK_WHITE).build());

        clients.add(clientBuilder.newInstance().setName("Client6").setSurname("").setId(UUID.randomUUID())
                .setPages(25).setColor(Color.COLOR).build());

        clients.add(clientBuilder.newInstance().setName("Client7").setSurname("").setId(UUID.randomUUID())
                .setPages(50).setColor(Color.COLOR).build());

        clients.add(clientBuilder.newInstance().setName("Client8").setSurname("").setId(UUID.randomUUID())
                .setPages(1000).setColor(Color.BLACK_WHITE).build());

        clients.add(clientBuilder.newInstance().setName("Client9").setSurname("").setId(UUID.randomUUID())
                .setPages(100).setColor(Color.BLACK_WHITE).build());

        clients.add(clientBuilder.newInstance().setName("Client10").setSurname("").setId(UUID.randomUUID())
                .setPages(25).setColor(Color.COLOR).build());

        clients.add(clientBuilder.newInstance().setName("Client11").setSurname("").setId(UUID.randomUUID())
                .setPages(50).setColor(Color.COLOR).build());

        clients.add(clientBuilder.newInstance().setName("Client12").setSurname("").setId(UUID.randomUUID())
                .setPages(1000).setColor(Color.BLACK_WHITE).build());

        return clients;
    }

    private static void prepareSysOut(String message) {
        System.out.println(new Timestamp(System.currentTimeMillis()) + " | " + Thread.currentThread().getName() + " | " + message);
        System.out.println();
    }
}
