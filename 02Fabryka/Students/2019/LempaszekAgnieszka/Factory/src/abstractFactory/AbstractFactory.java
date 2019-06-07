package abstractFactory;

import products.Cake;
import products.Coffee;
import products.Tea;

//interface for objects families
//only interface visible, not implementations

public interface AbstractFactory {
	Cake makeCake();
	Coffee makeCoffee();
	Tea makeTea();
}
