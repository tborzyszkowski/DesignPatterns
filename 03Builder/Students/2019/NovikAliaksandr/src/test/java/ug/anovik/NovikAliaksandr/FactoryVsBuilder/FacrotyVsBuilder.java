package ug.anovik.NovikAliaksandr.FactoryVsBuilder;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import FactoryVsBuilder.NewPhone;
import FactoryVsBuilder.Phone;
import FactoryVsBuilder.PhoneType;
import FactoryVsBuilder.factory.NewSimplePhoneFactory;
import FactoryVsBuilder.factory.SimplePhoneFactory;

public class FacrotyVsBuilder {

	private int LOOP = 1_000_000;
	private List<Phone> list;
	private List<NewPhone> nList;

	@Before
	public void beforeEach() {
		list = new ArrayList<>();
		nList = new ArrayList<>();
	}

	@Test
	public void createByBuilder() {


		for (int i = 0; i < LOOP; i++) {
			list.add(new Phone().phoneType(PhoneType.GAMING));
		}
		list = null;
	}

	@Test
	public void createByFactory() {
		SimplePhoneFactory factory = SimplePhoneFactory.getInstance();

		for (int i = 0; i < LOOP; i++) {
			list.add(factory.buildPhone(PhoneType.GAMING));
		}
		list = null;
	}

	@Test
	public void createByNewBuilder() {
		for (int i = 0; i < LOOP; i++) {
			nList.add(new NewPhone().phoneType(PhoneType.GAMING).price(new BigDecimal(100.00)).model("G"));
		}
		nList = null;
	}

	@Test
	public void createByNewFactory() {
		NewSimplePhoneFactory factory = NewSimplePhoneFactory.getInstance();

		for (int i = 0; i < LOOP; i++) {
			nList.add(factory.buildPhone(PhoneType.GAMING));
		}
		nList = null;
	}
	
	@After
	public void afterEach() {
		list = null;
		nList = null;
	}

}
