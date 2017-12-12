package builder;

public class RowerTurystycznyBuilder implements RowerBuilder {
	private Rower rower;
	
	public RowerTurystycznyBuilder(){
		this.rower = new Rower();
	}

	@Override
	public void buildOpony() {
		Opony opony = new Opony();
		opony.setTyp("zwykłe");
		opony.setLiczba(2);		
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
		przerzutka.setLiczba_biegow(5);		
		rower.setPrzerzutka(przerzutka);
	}

	@Override
	public Rower getRower() {
		return rower;
	}
}
