package twoWayAdapter;

public class Seacraft implements ISeacraft {
	private int speed = 0;

	@Override
	public void increaseRevs() {
		speed += 10;
		System.out.println("Seacraft engine increases revs to " + speed + " knots");
	}

	public int speed() {
		return speed;
	}
}