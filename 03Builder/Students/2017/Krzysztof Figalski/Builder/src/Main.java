import java.text.DecimalFormat;

import builder.Outfit;
import builder.OutfitBuilder;

public class Main {

	public static void main(String[] args) {

		OutfitBuilder outfitBuilder = new OutfitBuilder();
		
		DecimalFormat df = new DecimalFormat("#.00");

		Outfit casualOutfit = outfitBuilder.completeCasualOutfit();
		System.out.println("Casual outfit");
		casualOutfit.showItems();
		System.out.println("Total cost: " + df.format(casualOutfit.getCost()));

		System.out.println("\n");

		Outfit smartCasualOutfit = outfitBuilder.completeSmartCasualOutfit();
		System.out.println("Smart casual outfit");
		smartCasualOutfit.showItems();
		System.out.println("Total cost: " + df.format(smartCasualOutfit.getCost()));

	}

}
