
public class YellowButtonFourButtonholes extends Button {

	public YellowButtonFourButtonholes() {
		colour = "Yellow";
		numberOfButtonholes = 4;
	}

	@Override
	void produce() {
		System.out.println("Producing yellow button with 4 buttonholes");
	}

}
