package babeczka;

public class PiekarniaSmakowitaFactory implements PiekarniaFactory {

	@Override
	public Ksztalt przygotujKsztalt() {
		return new Okragla();
	}
}