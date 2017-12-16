package prototypeDeep;

public class Piosenka {
	private int id;
	private String tytul;
	private String wykonawca;
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getTytul() {
		return tytul;
	}
	public void setTytul(String tytul) {
		this.tytul = tytul;
	}
	public String getWykonawca() {
		return wykonawca;
	}
	public void setWykonawca(String wykonawca) {
		this.wykonawca = wykonawca;
	}
	@Override
	public String toString() {
		return "\nid: " + id + "; tytul: " + tytul + "; wykonawca: " + wykonawca;
	}	
}
