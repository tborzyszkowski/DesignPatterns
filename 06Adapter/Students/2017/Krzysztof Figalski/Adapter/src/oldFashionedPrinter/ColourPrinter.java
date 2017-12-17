package oldFashionedPrinter;

public class ColourPrinter implements IRegularPrinter {

	@Override
	public void printColour(String document) {

		System.out.println("Old Fashioned Color Printer prints: " + document);

	}

	@Override
	public void printBlackAndWhite(String document) {
	}

}
