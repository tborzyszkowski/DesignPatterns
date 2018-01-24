package design.patterns.facade;

import design.patterns.client.Client;
import design.patterns.copy.XeroCopy;
import design.patterns.copy.XeroCopyBuilder;
import design.patterns.printers.Printer;
import design.patterns.printers.state.WithoutBlackInkState;
import design.patterns.printers.state.WithoutColorInkState;
import design.patterns.printers.state.WithoutPaperState;

public class XeroFacade {

    public XeroCopy createCopy(Printer printer, Client client) {
        XeroCopy copy;
        //sprawdzenie czy jest możliwe wydrukowanie danego materiału na wybranej drukarce
        if (printer.getPaper() >= client.getPages() && ((printer.isColorPrinter() && printer.getColorInk() >= client.getPages())
                || (!printer.isColorPrinter() && printer.getBlackInk() >= client.getPages()))) {
            //jeśli tak, to drukujemy - budujemy xeroCopy, podliczamy koszt
            copy = buildCopy(client);
        } else {
            //w przeciwnym przypadku wysyłamy żądanie o uzupełnieniu brakuącego materiału do obserwatora i
            //po uzupełnieniu drukujemy materiał i obliczamy koszt
            if (printer.getPaper() < client.getPages()) {
                WithoutPaperState withoutPaperState = new WithoutPaperState();
                withoutPaperState.doAction(printer);
            }
            if (printer.getBlackInk() < client.getPages()) {
                WithoutBlackInkState withoutBlackInkState = new WithoutBlackInkState();
                withoutBlackInkState.doAction(printer);
            }
            if (printer.isColorPrinter() && printer.getColorInk() < client.getPages()) {
                WithoutColorInkState withoutColorInkState = new WithoutColorInkState();
                withoutColorInkState.doAction(printer);
            }
            copy = buildCopy(client);
        }
        modifyPrinter(printer, client);
        try {
            Thread.sleep(5000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return copy;
    }

    private XeroCopy buildCopy(Client client) {
        XeroCopyBuilder builder = new XeroCopyBuilder();
        return builder.newInstance().setClientId(client.getId()).setPages(client.getPages())
                .setColor(client.getColor()).countCost().build();
    }

    private void modifyPrinter(Printer printer, Client client) {
        printer.setPaper(printer.getPaper() - client.getPages());
        if (printer.isColorPrinter()) {
            printer.setColorInk(printer.getColorInk() - client.getPages());
        } else {
            printer.setBlackInk(printer.getBlackInk() - client.getPages());
        }
    }
}
