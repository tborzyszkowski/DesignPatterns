package builder;

public class RowerDirector {
	
	private RowerBuilder rowerBuilder;
	
	public RowerDirector(RowerBuilder rowerBuilder){
		this.rowerBuilder = rowerBuilder;
	}
	
	public void makeRower(){
		rowerBuilder.buildOpony();
		rowerBuilder.buildKierownica();
		rowerBuilder.buildPrzerzutka();
	}
	
	public Rower getRower(){
		return this.rowerBuilder.getRower();
	}
}
