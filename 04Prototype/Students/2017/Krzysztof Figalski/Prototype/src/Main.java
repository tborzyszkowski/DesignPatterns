
public class Main {

	public static void main(String[] args) {

		ButtonCache.generateObjects();

		Button clonedButton1 = (Button) ButtonCache.getBuuton("Yellow2");
		System.out.println("Button: colout=" + clonedButton1.getColour() + ", number of buttnholes="
				+ clonedButton1.getNumberOfNuttonholes());

		Button clonedButton2 = (Button) ButtonCache.getBuuton("Yellow4");
		System.out.println("Button: colout=" + clonedButton2.getColour() + ", number of buttnholes="
				+ clonedButton2.getNumberOfNuttonholes());

		Button clonedButton3 = (Button) ButtonCache.getBuuton("Black2");
		System.out.println("Button: colout=" + clonedButton3.getColour() + ", number of buttnholes="
				+ clonedButton3.getNumberOfNuttonholes());

		Button clonedButton4 = (Button) ButtonCache.getBuuton("Black4");
		System.out.println("Button: colout=" + clonedButton4.getColour() + ", number of buttnholes="
				+ clonedButton4.getNumberOfNuttonholes());
		
		System.out.println("Creating button in a loop...");
		for(int i=0;i<=10;i++) {
			Button clonedButton = (Button) ButtonCache.getBuuton("Yellow2_");
			System.out.println("\tButton: colout=" + clonedButton1.getColour() + ", number of buttnholes="
					+ clonedButton1.getNumberOfNuttonholes());
		}

	}

}
