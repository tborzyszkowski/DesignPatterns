package pluggableAdapter;

import java.util.function.Function;

public class Adapter extends Adaptee {
	private Function<Integer, String> converter;
	Adapter(Adaptee adapter){
	converter = i -> "The total amount is: " + adapter.convert(100, 4.3, i);
	}
	public String useConverter(int i){
	return converter.apply(i);
	}
	Adapter(InterbankCurrencyExchange ice){
	converter = ice.getConverter();
	}
	public void changeConverter(Function<Integer, String> converter){
	this.converter = converter;
	}
}
