package builder;

public class RowerTrojkolowyBuilder implements RowerBuilder {
	private Rower rower;
	
	public RowerTrojkolowyBuilder(){
		this.rower = new Rower();
	}

	@Override
	public void buildOpony() {
		Opony opony = new Opony();
		opony.setTyp("zwykłe");
		opony.setLiczba(3);		
		rower.setOpony(opony);
	}

	@Override
	public void buildKierownica() {
		Kierownica kierownica = new Kierownica();
		kierownica.setTyp("zwykła");
		rower.setKierownica(kierownica);
	}

	@Override
	public void buildPrzerzutka() {
		Przerzutka przerzutka = new Przerzutka();
		przerzutka.setLiczba_biegow(1);		
		rower.setPrzerzutka(przerzutka);
	}

	@Override
	public Rower getRower() {
		return rower;
	}
}
