package builder;

public class RowerWyczynowyBuilder implements RowerBuilder {
	private Rower rower;
	
	public RowerWyczynowyBuilder(){
		this.rower = new Rower();
	}

	@Override
	public void buildOpony() {
		Opony opony = new Opony();
		opony.setTyp("przełajowe");
		opony.setLiczba(2);		
		rower.setOpony(opony);
	}

	@Override
	public void buildKierownica() {
		Kierownica kierownica = new Kierownica();
		kierownica.setTyp("kolarska");
		rower.setKierownica(kierownica);
	}

	@Override
	public void buildPrzerzutka() {
		Przerzutka przerzutka = new Przerzutka();
		przerzutka.setLiczba_biegow(10);		
		rower.setPrzerzutka(przerzutka);
	}

	@Override
	public Rower getRower() {
		return rower;
	}
}
