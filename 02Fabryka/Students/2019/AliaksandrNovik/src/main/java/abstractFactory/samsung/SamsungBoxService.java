package abstractFactory.samsung;

import abstractFactory.IBoxService;

public class SamsungBoxService implements IBoxService{

	@Override
	public void pack() {
		System.out.println("Samsung boxing");
	}

}
