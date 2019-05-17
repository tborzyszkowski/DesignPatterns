package twoWayAdapter;

public class Seabird extends Seacraft implements IAircraft {
	private int height = 0;

	@Override
	public void takeOff() {
		while (!airborne()) {
			increaseRevs();
		}
	}

	@Override
	public void increaseRevs() {
		super.increaseRevs();
		if (speed() > 40) {
			height += 100;
		}
	}

	public boolean airborne() {
		return speed() > 50;
	}

	public int height() {
		return height;
	}

}