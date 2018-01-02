package oldFashionedPrinter;

public class BlackAndWhitePrinter implements IRegularPrinter {

	@Override
	public void printBlackAndWhite(String document) {

		System.out.println("Old Fashioned Black And White Printer prints: " + document);

	}

	@Override
	public void printColour(String document) {
	}

}
