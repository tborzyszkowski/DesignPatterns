package builder;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;

import items.Item;

public class Outfit {

	private List<Item> items = new ArrayList<Item>();

	public void addItem(Item item) {
		items.add(item);
	}

	public double getCost() {
		double cost = 0.0;

		for (Item item : items) {
			cost += item.price();
		}
		return cost;
	}

	public void showItems() {

		for (Item item : items) {
			System.out.print("Item : " + item.name());
			System.out.print(", Bag : " + item.bag().bagName());
			
			DecimalFormat df = new DecimalFormat("#.00");
			System.out.println(", Price : " + df.format(item.price()));
		}
	}

}
