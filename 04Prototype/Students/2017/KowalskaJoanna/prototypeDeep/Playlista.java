package prototypeDeep;

import java.util.ArrayList;
import java.util.List;

public class Playlista implements Cloneable {
	
	private String nazwa;
	List<Piosenka> piosenki = new ArrayList<>();
	
	public String getNazwa() {
		return nazwa;
	}
	public void setNazwa(String nazwa) {
		this.nazwa = nazwa;
	}
	
	public List<Piosenka> getPiosenki() {
		return piosenki;
	}
	public void setPiosenki(List<Piosenka> piosenki) {
		this.piosenki = piosenki;
	}
	
	@Override
	public String toString() {
		return "Nazwa playlisty: " + nazwa + piosenki;
	}
	
	@Override
	protected Playlista clone() throws CloneNotSupportedException {
		Playlista playlista = new Playlista();
		
		for(Piosenka p : this.getPiosenki()) {
			playlista.getPiosenki().add(p);
		}		
		return playlista;
	}
	
	public void dodajPiosenki() {
		Piosenka p = new Piosenka();
		p.setId(1);
		p.setTytul("Luna rossa");	
		p.setWykonawca("Claudio Villa");
		getPiosenki().add(p);
		Piosenka p2 = new Piosenka();
		p2.setId(2);
		p2.setTytul("Azzurro");	
		p2.setWykonawca("Adriano Celentano");
		getPiosenki().add(p2);
		Piosenka p3 = new Piosenka();
		p3.setId(3);
		p3.setTytul("Vamos a bailar");	
		p3.setWykonawca("Paola e Chiara");
		getPiosenki().add(p3);
		Piosenka p4 = new Piosenka();
		p4.setId(4);
		p4.setTytul("Tre parole");	
		p4.setWykonawca("Valeria Rossi");
		getPiosenki().add(p4);
	}
}
