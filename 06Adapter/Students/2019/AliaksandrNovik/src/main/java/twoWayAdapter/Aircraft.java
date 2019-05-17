package twoWayAdapter;

public class Aircraft implements IAircraft {

	private boolean airborne;
	private int height;

	public Aircraft() {
		airborne = false;
		height = 0;
	}

	@Override
	public void takeOff() {
		System.out.println("Aircraft engine takeoff");
		airborne = true;
		height = 200;
	}

	@Override
	public boolean airborne() {
		return airborne;
	}

	@Override
	public int height() {
		return height;
	}
}