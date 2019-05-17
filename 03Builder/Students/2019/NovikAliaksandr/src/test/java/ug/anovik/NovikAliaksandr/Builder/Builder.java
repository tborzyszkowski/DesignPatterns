package ug.anovik.NovikAliaksandr.Builder;

import org.junit.Test;

import Builder.BudgetaryPhoneBuilder;
import Builder.Phone;
import Builder.PhoneBuilder;
import Builder.PhoneBuilderImpl;

public class Builder {

	@Test
	public void buildPhone() {
		PhoneBuilder builder = new PhoneBuilderImpl();
		BudgetaryPhoneBuilder budgetaryPhoneBuilder = new BudgetaryPhoneBuilder(builder);
		Phone phone = budgetaryPhoneBuilder.getPhone();
		System.out.println(phone);
	}
	
}
