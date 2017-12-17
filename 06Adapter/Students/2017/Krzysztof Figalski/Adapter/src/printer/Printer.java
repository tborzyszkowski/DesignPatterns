package printer;

import adapter.PrinterAdapter;
import enums.DocumentTypes;

public class Printer implements IPrinter {

	PrinterAdapter printerAdapter;

	@Override
	public void print(DocumentTypes documentType, String document) {

		if (documentType.equals(DocumentTypes.THREE_D)) {
			System.out.println("3d Printer prints: " + document);
		} else if (documentType.equals(DocumentTypes.BLACK_AND_WHITE) || documentType.equals(DocumentTypes.COLOUR)) {
			printerAdapter = new PrinterAdapter(documentType);
			printerAdapter.print(documentType, document);
		} else {
			System.err.println("Wrong type of document type given");
		}

	}

}
