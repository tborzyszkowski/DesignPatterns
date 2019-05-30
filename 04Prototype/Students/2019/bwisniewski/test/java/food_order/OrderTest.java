package food_order;

import static org.junit.Assert.*;

import org.junit.Test;

public class OrderTest {

	@Test
	public void orderDeepTest() throws CloneNotSupportedException {
		Order order = new Order(new Extra("Lizak"), new MainDish("Naggetsy", new Drink("Sok Winogronowy")), "30.99zl");

		assertEquals(order.getExtra().getExtra(), "Lizak");
		assertEquals(order.getMainDish().getMainDish(), "Naggetsy");
		assertEquals(order.getMainDish().getDrink().getDrinkType(), "Sok Winogronowy");
		assertEquals(order.getPrice(), "30.99zl");
		
		
		Order copyOrder = (Order) order.clone();
		copyOrder.getExtra().setExtra("Cukierek");
		copyOrder.getMainDish().setMainDish("Kapsalon");
		copyOrder.getMainDish().getDrink().setDrinkType("Monsterek");
		copyOrder.setPrice("26.98zl");
		
		assertEquals(copyOrder.getExtra().getExtra(), "Cukierek");
		assertEquals(copyOrder.getMainDish().getMainDish(), "Kapsalon");
		assertEquals(copyOrder.getMainDish().getDrink().getDrinkType(), "Monsterek");
		assertEquals(copyOrder.getPrice(), "26.98zl");
		
		assertEquals(order.getExtra().getExtra(), "Lizak");
		assertEquals(order.getMainDish().getMainDish(), "Naggetsy");
		assertEquals(order.getMainDish().getDrink().getDrinkType(), "Sok Winogronowy");
		assertEquals(order.getPrice(), "30.99zl");
	}
	
	@Test
	public void orderShallowTest() throws CloneNotSupportedException {
		Order order = new Order(new Extra("Lizak"), new MainDish("Naggetsy", new Drink("Sok Winogronowy")), "30.99zl");

		assertEquals(order.getExtra().getExtra(), "Lizak");
		assertEquals(order.getMainDish().getMainDish(), "Naggetsy");
		assertEquals(order.getMainDish().getDrink().getDrinkType(), "Sok Winogronowy");
		assertEquals(order.getPrice(), "30.99zl");
		
		
		Order copyOrder = (Order) order.shallowCopy();
		copyOrder.getExtra().setExtra("Cukierek");
		copyOrder.getMainDish().setMainDish("Kapsalon");
		copyOrder.getMainDish().getDrink().setDrinkType("Monsterek");
		copyOrder.setPrice("26.98zl");
		
		assertEquals(copyOrder.getExtra().getExtra(), "Cukierek");
		assertEquals(copyOrder.getMainDish().getMainDish(), "Kapsalon");
		assertEquals(copyOrder.getMainDish().getDrink().getDrinkType(), "Monsterek");
		assertEquals(copyOrder.getPrice(), "26.98zl");
		
		assertNotEquals(order.getExtra().getExtra(), "Lizak");
		assertNotEquals(order.getMainDish().getMainDish(), "Naggetsy");
		assertNotEquals(order.getMainDish().getDrink().getDrinkType(), "Sok Winogronowy");
		assertEquals(order.getPrice(), "30.99zl");
	}
}
