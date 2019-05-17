package pluggableAdapter;

import java.util.function.Function;

public class InterbankCurrencyExchange {
	private Function<Integer, String> converter = i -> {
		Double d = 100.d / 4.6473;
		return "According to interbank currency exchange the total amount is: " + (d).toString().substring(0, 3 + i);
	};

	public Function<Integer, String> getConverter() {
		return converter;
	}
}
