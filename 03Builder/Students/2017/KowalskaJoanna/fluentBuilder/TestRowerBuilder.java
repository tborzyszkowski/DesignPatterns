package fluentBuilder;

public class TestRowerBuilder {
	public static void main(String[] args){
		
		Rower rower = new Rower.Builder("Wyczynowy") 
				.opony(2) 
				.kierownica("kolarska")
				.przerzutka(10)
				.build();
		System.out.println(rower);		
		
		Rower rower2 = new Rower.Builder("Turystyczny") 
				.opony(2) 
				.kierownica("zwykła")
				.przerzutka(5)
				.build();
		System.out.println(rower2);	
		
		Rower rower3 = new Rower.Builder("Trójkołowy") 
				.opony(3) 
				.kierownica("zwykła")
				.przerzutka(1)
				.build();
		System.out.println(rower3);	
	}
}
