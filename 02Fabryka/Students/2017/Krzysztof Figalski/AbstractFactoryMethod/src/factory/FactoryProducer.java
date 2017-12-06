package factory;

import enums.Components;

public class FactoryProducer {

	public static AbstractFactory getFactory(Components choice) {
		if (choice.equals(Components.COVER)) {
			return new CoverFactory();

		} else if (choice.equals(Components.PAGES)) {
			return new PagesFactory();
		}

		return null;
	}

}
