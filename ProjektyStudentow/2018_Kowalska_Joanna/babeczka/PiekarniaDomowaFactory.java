package babeczka;

public class PiekarniaDomowaFactory implements PiekarniaFactory {

	@Override
	public Ksztalt przygotujKsztalt() {
		return new Kwadratowa();
	}
}