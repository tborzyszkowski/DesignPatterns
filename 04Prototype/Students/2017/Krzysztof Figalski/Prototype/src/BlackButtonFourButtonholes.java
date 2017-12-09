
public class BlackButtonFourButtonholes extends Button {

	public BlackButtonFourButtonholes() {
		colour = "Black";
		numberOfButtonholes = 4;
	}

	@Override
	void produce() {
		System.out.println("Producing black button with 4 buttonholes");
	}
}
