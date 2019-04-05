package abstractFactory.xiaomi;

import abstractFactory.ITestService;

public class XiaomiTestService implements ITestService {

	@Override
	public void crashTest() {
		System.out.println("Xiaomi crashTest complited");
	}

	@Override
	public void batteryLifeTest() {
		System.out.println("Xiaomi battery life test complited");
	}

	@Override
	public void stressTest() {
		System.out.println("Xiaomi stressTest complited");
	}

}
