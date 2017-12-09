package factory.simplefactoryclassregistration;

import java.lang.reflect.InvocationTargetException;

import javax.management.modelmbean.ModelMBean;

import factory.common.exception.UnsupportedCarSegmentException;
import factory.simplefactoryclassregistration.car.Car;
import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.car.ford.Focus;
import factory.simplefactoryclassregistration.car.ford.Mondeo;
import factory.simplefactoryclassregistration.car.mercedes.CClass;
import factory.simplefactoryclassregistration.car.mercedes.EClass;
import factory.simplefactoryclassregistration.car.mercedes.SClass;
import factory.simplefactoryclassregistration.car.opel.Astra;
import factory.simplefactoryclassregistration.car.opel.Insignia;
import factory.simplefactoryclassregistration.factory.CarFactory;
import factory.simplefactoryclassregistration.factory.FordFactory;
import factory.simplefactoryclassregistration.factory.MercedesFactory;
import factory.simplefactoryclassregistration.factory.OpelFactory;

public class Test {

	public static void main(String[] args)
			throws IllegalAccessException, InstantiationException, InvocationTargetException, ClassNotFoundException {
		// TODO Auto-generated method stub
		loadAllCarClasses();

		CarFactory carFactory = MercedesFactory.getInstance();
		testCreateAllSegmentsCarsForFactory(carFactory);
		carFactory = FordFactory.getInstance();
		testCreateAllSegmentsCarsForFactory(carFactory);
		carFactory = OpelFactory.getInstance();
		testCreateAllSegmentsCarsForFactory(carFactory);
	}

	private static void testCreateAllSegmentsCarsForFactory(CarFactory carFactory)
			throws IllegalAccessException, InstantiationException, InvocationTargetException {
		Car car;
		for (CarSegment carSegment : CarSegment.values()) {
			try {
				car = carFactory.createCar(carSegment);
				System.out.println("car " + car + " ordered");
			} catch (UnsupportedCarSegmentException ex) {
				System.out.println(ex.getMessage());
			}
		}
	}

	private static void loadAllCarClasses() throws IllegalAccessException, InstantiationException {
		Focus.class.newInstance();
		Mondeo.class.newInstance();
		CClass.class.newInstance();
		EClass.class.newInstance();
		SClass.class.newInstance();
		Astra.class.newInstance();
		Insignia.class.newInstance();
	}
}
