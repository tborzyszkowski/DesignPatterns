
import covers.ICover;
import enums.Components;
import enums.Tittles;
import factory.AbstractFactory;
import factory.FactoryProducer;
import texts.IPages;

public class PrintingHouse {

	public static void main(String[] args) {

		AbstractFactory coverFactory = FactoryProducer.getFactory(Components.COVER);
		AbstractFactory pagesFactory = FactoryProducer.getFactory(Components.PAGES);

		// A Little Life
		System.out.println("Printing \"A Little Life\"...");
		ICover cover = coverFactory.getCover(Tittles.A_LITTLE_LIFE);
		cover.print();
		IPages pages = pagesFactory.getPages(Tittles.A_LITTLE_LIFE);
		pages.printPages();

		// The Sisters Brothers
		System.out.println("Printing \"The Sisters Brothers\"...");
		cover = coverFactory.getCover(Tittles.THE_SISTER_BROTHERS);
		cover.print();
		pages = pagesFactory.getPages(Tittles.THE_SISTER_BROTHERS);
		pages.printPages();

	}

}
