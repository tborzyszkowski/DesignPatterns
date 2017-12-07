package adapter;

import enums.DocumentTypes;
import oldFashionedPrinter.BlackAndWhitePrinter;
import oldFashionedPrinter.ColourPrinter;
import oldFashionedPrinter.IRegularPrinter;
import printer.IPrinter;

public class PrinterAdapter implements IPrinter {

	IRegularPrinter regularPrinter;

	public PrinterAdapter(DocumentTypes documentType) {

		if (documentType.equals(DocumentTypes.BLACK_AND_WHITE)) {
			regularPrinter = new BlackAndWhitePrinter();
		} else if (documentType.equals(DocumentTypes.COLOUR)) {
			regularPrinter = new ColourPrinter();
		}
	}

	@Override
	public void print(DocumentTypes documentType, String document) {

		if (documentType.equals(DocumentTypes.BLACK_AND_WHITE)) {
			regularPrinter.printBlackAndWhite(document);
		} else if (documentType.equals(DocumentTypes.COLOUR)) {
			regularPrinter.printColour(document);
		}
	}

}
