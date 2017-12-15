package builder;

public class TestRowerBuilder {
	public static void main(String[] args){
		
		RowerBuilder rowerBuilder = new RowerWyczynowyBuilder();
		RowerDirector rowerDirector = new RowerDirector(rowerBuilder);
		rowerDirector.makeRower();		
		Rower rower = rowerDirector.getRower();
		System.out.println("Rower wyczynowy:\n" + rower);
		
		RowerBuilder rowerBuilder2 = new RowerTurystycznyBuilder();
		RowerDirector rowerDirector2 = new RowerDirector(rowerBuilder2);
		rowerDirector2.makeRower();		
		Rower rower2 = rowerDirector2.getRower();
		System.out.println("Rower turystyczny:\n" + rower2);
		
		RowerBuilder rowerBuilder3 = new RowerTrojkolowyBuilder();
		RowerDirector rowerDirector3 = new RowerDirector(rowerBuilder3);
		rowerDirector3.makeRower();		
		Rower rower3 = rowerDirector3.getRower();
		System.out.println("Rower trójkołowy:\n" + rower3);
	}
}
