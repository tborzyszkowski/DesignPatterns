package pluggableAdapter;

import java.util.function.Function;

import org.junit.Before;
import org.junit.Test;

public class PluggableAdapterTest {

	Adapter adapter1;

	Adapter adapter2;

	@Before
	public void beforeEach() {
		adapter1 = new Adapter(new Adaptee());
		adapter2 = new Adapter(new InterbankCurrencyExchange());
	}

	@Test
	public void commonAdapter() {
		System.out.println(adapter1.useConverter(2));
	}

	@Test
	public void commonAdapterTwo() {
		System.out.println(adapter2.useConverter(5));
	}

	@Test
	public void changeAdapter() {

		Function<Integer, String> f = i -> {
			Double d = (100.d / 4.6) * 1.03;
			return "The total amount plus 3% is " + (d).toString().substring(0, 3 + i);
		};
		adapter2.changeConverter(f);

		System.out.println(adapter2.useConverter(5));

	}

}
