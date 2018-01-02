package builder;
import items.shirts.CheckedShirt;
import items.shirts.WeddingShirt;
import items.trousers.BlueJeans;
import items.trousers.Chinos;

public class OutfitBuilder {

	public Outfit completeCasualOutfit() {
		Outfit outfit = new Outfit();
		outfit.addItem(new BlueJeans());
		outfit.addItem(new CheckedShirt());

		return outfit;
	}

	public Outfit completeSmartCasualOutfit() {
		Outfit outfit = new Outfit();
		outfit.addItem(new Chinos());
		outfit.addItem(new WeddingShirt());

		return outfit;
	}

}
