package food_order;

import static org.junit.Assert.*;

import org.junit.Test;

public class ExtraTest {

	
	@Test
	public void extraDeepTest() throws CloneNotSupportedException{
		
		Extra extra = new Extra("Frytken");
		assertEquals(extra.getExtra(), "Frytken");
		
		Extra cloneExtra = (Extra) extra.clone();
		cloneExtra.setExtra("Bulken");
		assertEquals(cloneExtra.getExtra(), "Bulken");
		
	}
	
}
