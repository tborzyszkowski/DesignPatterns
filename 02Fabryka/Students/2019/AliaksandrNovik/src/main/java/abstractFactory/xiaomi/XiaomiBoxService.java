package abstractFactory.xiaomi;

import abstractFactory.IBoxService;

public class XiaomiBoxService implements IBoxService{

	@Override
	public void pack() {
		System.out.println("Xiaomi boxing");
	}

}
