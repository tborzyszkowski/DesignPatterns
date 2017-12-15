package builder;

public class Przerzutka {
	private int liczba_biegow;

	public int getLiczba_biegow() {
		return liczba_biegow;
	}

	public void setLiczba_biegow(int liczba_biegow) {
		this.liczba_biegow = liczba_biegow;
	}

	@Override
	public String toString() {
		return "Liczba biegow w przerzutce: " + liczba_biegow + "\n";
	}
}
