package items.shirts;

import bags.Bag;
import bags.PlasticBag;
import items.Item;

public abstract class Shirt implements Item{
	
	@Override
	public Bag bag() {
		return new PlasticBag();
	}

	@Override
	public abstract double price();

}
