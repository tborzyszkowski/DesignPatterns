import java.util.HashMap;
import java.util.Map;

public class ButtonCache {

	private static Map<String, Button> buttonMap = new HashMap<String, Button>();

	public static Button getBuuton(String description) {
		Button cachedButton = buttonMap.get(description);
		return (Button) cachedButton.clone();
	}

	public static void generateObjects() {
		YellowButtonTwoButtonholes yellowButtonTwoButtonholes = new YellowButtonTwoButtonholes();
		yellowButtonTwoButtonholes.setDescription("Yellow2");
		buttonMap.put(yellowButtonTwoButtonholes.getDescription(), yellowButtonTwoButtonholes);

		YellowButtonFourButtonholes yellowButtonFourButtonholes = new YellowButtonFourButtonholes();
		yellowButtonFourButtonholes.setDescription("Yellow4");
		buttonMap.put(yellowButtonFourButtonholes.getDescription(), yellowButtonFourButtonholes);

		BlackButtonTwoButtonholes blackButtonTwoButtonholes = new BlackButtonTwoButtonholes();
		blackButtonTwoButtonholes.setDescription("Black2");
		buttonMap.put(blackButtonTwoButtonholes.getDescription(), blackButtonTwoButtonholes);

		BlackButtonFourButtonholes blackButtonFourButtonholes = new BlackButtonFourButtonholes();
		blackButtonFourButtonholes.setDescription("Black4");
		buttonMap.put(blackButtonFourButtonholes.getDescription(), blackButtonFourButtonholes);

	}

}
