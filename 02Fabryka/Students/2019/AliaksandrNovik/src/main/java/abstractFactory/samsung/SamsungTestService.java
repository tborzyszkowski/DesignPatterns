package abstractFactory.samsung;

import abstractFactory.ITestService;

public class SamsungTestService implements ITestService {

	@Override
	public void crashTest() {
		System.out.println("Samsung crash test is complited");
	}

	@Override
	public void batteryLifeTest() {
		System.out.println("Samsung battery life test is complited");
	}

	@Override
	public void stressTest() {
		System.out.println("Samsung stress test is complited");
	}

}
