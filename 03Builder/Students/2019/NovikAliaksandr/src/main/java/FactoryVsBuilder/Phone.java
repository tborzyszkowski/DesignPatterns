package FactoryVsBuilder;

import java.math.BigDecimal;

public class Phone {
	protected PhoneType phoneType;

	public PhoneType getPhoneType() {
		return phoneType;
	}

	/**
	 * phoneType method is required for builder purposes
	 * 
	 */
	public Phone phoneType(PhoneType phoneType) {
		this.phoneType = phoneType;
		return this;
	}

	/**
	 * price method is required for builder purposed
	 * 
	 */

	public void setPhoneType(PhoneType phoneType) {
		this.phoneType = phoneType;
	}

	@Override
	public String toString() {
		return "Phone [phoneType=" + phoneType + "]";
	}

}
