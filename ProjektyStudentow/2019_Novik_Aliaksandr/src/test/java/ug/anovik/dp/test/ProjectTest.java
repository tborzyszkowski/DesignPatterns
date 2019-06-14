package ug.anovik.dp.test;

import static org.junit.Assert.assertTrue;

import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.function.Function;

import org.junit.Test;

import ug.anovik.dp.Camera;
import ug.anovik.dp.Manager;
import ug.anovik.dp.Memory;
import ug.anovik.dp.MobileDevice;
import ug.anovik.dp.MobileDeviceFactory;
import ug.anovik.dp.Phone;
import ug.anovik.dp.PhoneFactory;
import ug.anovik.dp.PhotoType;
import ug.anovik.dp.Tablet;
import ug.anovik.dp.TabletFactory;
import ug.anovik.dp.adapter.Antutu;
import ug.anovik.dp.adapter.Geekbench;
import ug.anovik.dp.adapter.Ranking;
import ug.anovik.dp.adapter.Rankingable;
import ug.anovik.dp.builder.Address;
import ug.anovik.dp.builder.Company;
import ug.anovik.dp.builder.Order;
import ug.anovik.dp.builder.OrderBuilder;
import ug.anovik.dp.facade.MobileDeviceFacade;
import ug.anovik.dp.observer.NewPhoneObserver;
import ug.anovik.dp.observer.NewPhonesTopic;
import ug.anovik.dp.observer.Observer;

public class ProjectTest {

	@Test
	public void createMobileDeviceByAbstractFactory() {

		List<Camera> cameras = Arrays.asList(new Camera(24, 2.0, PhotoType.WIDE),
				new Camera(48, 2.4, PhotoType.ULTRAWIDE), new Camera(48, 2.4, PhotoType.TELEPHOTO));

		MobileDevice phone = MobileDeviceFactory
				.getMobileDevice(new PhoneFactory("Snapdragon 858", 6.2d, 4100, new Memory(128, 4, true), cameras));

		System.out.println("Next device has been created: " + phone);
	}

	@Test
	public void copyDeviceUsingDeepCloneByPrototype() throws CloneNotSupportedException {

		MobileDevice tablet = MobileDeviceFactory.getMobileDevice(new TabletFactory("Spreadtrum SC9830", 7.0d, 4000,
				new Memory(8, 2, true), Arrays.asList(new Camera(24, 2.0, PhotoType.WIDE))));

		Manager<String, MobileDevice> manager = new Manager<>();

		manager.addDevice("Galaxy Tab A5", tablet);

		Tablet clonedTablet = (Tablet) manager.getDevice("Galaxy Tab A5").deepCopy();
		assertTrue(tablet.equals(clonedTablet));
	}

	@Test
	public void copyDeviceUsingShallowCloneByPrototype() throws CloneNotSupportedException {

		MobileDevice tablet = MobileDeviceFactory.getMobileDevice(new TabletFactory("Spreadtrum SC9830", 7.0d, 4000,
				new Memory(8, 2, true), Arrays.asList(new Camera(24, 2.0, PhotoType.WIDE))));

		Manager<String, MobileDevice> manager = new Manager<>();

		manager.addDevice("Galaxy Tab A5", tablet);

		Tablet clonedTablet = (Tablet) manager.getDevice("Galaxy Tab A5").shallowCopy();
		assertTrue(tablet.equals(clonedTablet));
	}

	@Test
	public void useFacadeToCloneDevice() throws CloneNotSupportedException {
		Phone phone = MobileDeviceFacade.clonePhone("Samsung Galxy S10");
		System.out.println(phone);
	}
	
	@Test
	public void observerTest() {

		List<Camera> cameras = Arrays.asList(new Camera(24, 2.0, PhotoType.WIDE),
				new Camera(48, 2.4, PhotoType.ULTRAWIDE), new Camera(48, 2.4, PhotoType.TELEPHOTO));

		MobileDevice phone = MobileDeviceFactory
				.getMobileDevice(new PhoneFactory("Snapdragon 858", 6.2d, 4100, new Memory(128, 4, true), cameras));
		MobileDevice tablet = MobileDeviceFactory.getMobileDevice(new TabletFactory("Spreadtrum SC9830", 7.0d, 4000,
				new Memory(8, 2, true), Arrays.asList(new Camera(24, 2.0, PhotoType.WIDE))));
		
		NewPhonesTopic topic = new NewPhonesTopic();

		Observer obs1 = new NewPhoneObserver("Obs1");
		Observer obs2 = new NewPhoneObserver("Obs2");
		Observer obs3 = new NewPhoneObserver("Obs2");

		topic.register(obs1);
		topic.register(obs2);
		topic.register(obs3);

		obs1.setSubject(topic);
		obs2.setSubject(topic);
		obs3.setSubject(topic);

		obs1.update();
		
		topic.postNewDevice("Galaxy Tab A", tablet);
		topic.postNewDevice("Samsung Galaxy S9", phone);

	}
	
	@Test
	public void adapterTest() throws CloneNotSupportedException {

		Phone phone = MobileDeviceFacade.clonePhone("Samsung Galxy S10");

		Rankingable rank = new Rankingable(phone);
		Ranking ranking = new Ranking(rank);
		
		Geekbench gb = new Geekbench(phone);
		Ranking ranking2 = new Ranking(gb);
		System.out.println(ranking2.useValuer(5));

		Antutu at = new Antutu(phone);
		Ranking ranking3 = new Ranking(at);
		System.out.println(ranking3.useValuer(5));

		Function<MobileDevice, Function<Integer, String>> myValuer = mobDev -> {
			Function<Integer, String> valuer;
			valuer = i -> "The total score by Custom valuer is: "
					+ (mobDev.getMemory().getRom() + i * 1000) / (mobDev.getMemory().getRom() - i)
					+ mobDev.getMemory().getRom();
			return valuer;
		};
		Function<Integer, String> customValuer = myValuer.apply(phone); 
		ranking.changeValuer(customValuer);
		System.out.println(ranking.useValuer(5));

	}
	
	@Test
	public void builderTest() {
		Address address = new Address("Warszawa", "Kopernik", "23A", "33-089");
		Company company = new Company("SomeFakeCompany", address);
		Map<MobileDevice, Integer> orderList = new HashMap<>();
		orderList.put(MobileDeviceFacade.getManager().getDevice("Samsung Galxy S9"), 1000);
		orderList.put(MobileDeviceFacade.getManager().getDevice("Samsung Galxy S10"), 800);
		
		Order order = new OrderBuilder().setRequeredFields(1, company, orderList).setOrderDate().setVATrequired(true).build();
		System.out.println(order);
		
	}
}
