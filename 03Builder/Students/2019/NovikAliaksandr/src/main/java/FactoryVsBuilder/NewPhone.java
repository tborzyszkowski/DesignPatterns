package FactoryVsBuilder;

import java.math.BigDecimal;

public class NewPhone {
	protected PhoneType phoneType;
	protected BigDecimal price;
	protected String model;

	public PhoneType getPhoneType() {
		return phoneType;
	}

	/**
	 * phoneType method is required for builder purposes
	 * 
	 */
	public NewPhone phoneType(PhoneType phoneType) {
		this.phoneType = phoneType;
		return this;
	}

	/**
	 * price method is required for builder purposes
	 * 
	 */
	public NewPhone price(BigDecimal price) {
		this.price = price;
		return this;
	}
	
	/**
	 * model method is required for builder purposes
	 */
	public NewPhone model(String model) {
		this.model = model;
		return this;
	}

	public void setPhoneType(PhoneType phoneType) {
		this.phoneType = phoneType;
	}

	public BigDecimal getPrice() {
		return price;
	}

	public void setPrice(BigDecimal price) {
		this.price = price;
	}

	
}
