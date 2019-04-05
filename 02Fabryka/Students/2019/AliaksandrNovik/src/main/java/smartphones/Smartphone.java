package smartphones;

public abstract class Smartphone {

	protected String model;
	protected double display;
	protected String proc;
	protected short battery;

	public void phoneAssembling() {
		System.out.println("Model: " + model);
		System.out.println("Display size: " + display + "  inches");
		System.out.println("CPU model: " + proc);
		System.out.println("Battery capacity: " + battery + "mAh");
	}

	public void crashTest() {
		System.out.println("Crash test is complited");
	}

	public void batteryLifeTest() {
		System.out.println("Battery life test is complited");
	}

	public void stressTest() {
		System.out.println("Stress test is complited");
	}

	public void pack() {
		System.out.println("Pack smartphone");
	}
}