package singletontest;

import static org.junit.Assert.assertTrue;

import org.junit.Before;
import org.junit.Test;

import enumsingletone.EnumSingletone;

public class TestEnumSingletone {
	
	private EnumSingletone instanceOne;
	private EnumSingletone instanceTwo;
	
	@Before
	public void executeBeforeEach() {
		instanceOne = EnumSingletone.INSTANCE;
		instanceTwo = EnumSingletone.INSTANCE;
	}
	
	@Test
	public void sameInstances() {
		boolean isSame = instanceOne.hashCode() == instanceTwo.hashCode();
		assertTrue(isSame);
	}

	
	
}
