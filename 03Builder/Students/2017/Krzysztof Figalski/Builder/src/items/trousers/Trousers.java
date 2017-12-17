package items.trousers;

import bags.Bag;
import bags.PlasticBag;
import items.Item;

public abstract class Trousers implements Item {

	@Override
	public Bag bag() {
		return new PlasticBag();
	}

	@Override
	public abstract double price();

}
