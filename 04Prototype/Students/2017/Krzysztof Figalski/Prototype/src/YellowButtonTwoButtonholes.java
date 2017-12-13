
public class YellowButtonTwoButtonholes extends Button {

	public YellowButtonTwoButtonholes() {
		colour = "Yellow";
		numberOfButtonholes = 2;
	}

	@Override
	void produce() {
		System.out.println("Producing yellow button with 2 buttonholes");
	}

}
