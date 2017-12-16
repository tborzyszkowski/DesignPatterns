package prototypeShallow;

public class TestShallow {
	public static void main(String[] args) throws CloneNotSupportedException {
		
		Playlista playlista = new Playlista();
    	playlista.setNazwa("Italian Hits");
    	playlista.dodajPiosenki();
		System.out.println("Playlista Italian Hits stan początkowy:");
		System.out.println(playlista);
				
		Playlista cloned = (Playlista)playlista.clone();
		System.out.println("\nNazwa sklonowanej playlisty:");
		System.out.println(cloned.getNazwa());
		cloned.setNazwa("Cloned Italian Hits");
				
		System.out.println("\nUsuwam 2 piosenkę z playlisty Italian Hits:");
		playlista.getPiosenki().remove(1);
		
		System.out.println("\nPlaylista Italian Hits:");
		System.out.println(playlista);
		System.out.println("\nPlaylista Cloned Italian Hits (sklonowana):");
		System.out.println(cloned);
	}
}
