package proste;

public class FabrykaFigur {

	private static FabrykaFigur instance = null;

	private FabrykaFigur() {
	}

	public static FabrykaFigur createInstance() {
		if (instance == null) {
			instance = new FabrykaFigur();
		}
		return instance;
	}

	public static Figura stworzFigure(FiguraType figuraType) {
		switch (figuraType) {
		case Prostokat:
			return new Prostokat();
		case Kwadrat:
			return new Kwadrat();
		default:
			return null;
		}
	}
}
