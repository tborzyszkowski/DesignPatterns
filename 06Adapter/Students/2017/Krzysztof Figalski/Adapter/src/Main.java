import enums.DocumentTypes;
import printer.IPrinter;
import printer.Printer;

public class Main {

	public static void main(String[] args) {

		IPrinter printer = new Printer();
		
		printer.print(DocumentTypes.THREE_D, "3d document");
		printer.print(DocumentTypes.BLACK_AND_WHITE, "black and white document");
		printer.print(DocumentTypes.COLOUR, "colour document");
		

	}

}
