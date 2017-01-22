package commands;

/**
 * Created by jakub on 1/22/17.
 */
public class HelpCommand extends ActionCommand {
    @Override
    public void execute() {
        System.out.println("dostepne api: \n \n" +
                "showall [dotted/dashed] - wypisuje zawartosc rejestru z opcjonalnym dekoratorem \n" +
                "exit - wychodzi z programu \n" +
                "area <figureName> <param1 param 2 ...> - oblicza pole zadanej figury dla podanych sensownych prametrów np: area rectangle 2 2\n" +
                "help - pomoc\n");
    }
}
