
public class BlackButtonTwoButtonholes extends Button {

	public BlackButtonTwoButtonholes() {
		colour = "Black";
		numberOfButtonholes = 2;
	}

	@Override
	void produce() {
		System.out.println("Producing black button with 2 buttonholes");
	}
}
