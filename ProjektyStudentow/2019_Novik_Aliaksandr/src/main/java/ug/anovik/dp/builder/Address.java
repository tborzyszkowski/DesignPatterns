package ug.anovik.dp.builder;

public class Address {
	
	private String city;
	private String street;
	private String houseNr;
	private String postCode;
	
	public Address(String city, String street, String houseNr, String postCode) {
		super();
		this.city = city;
		this.street = street;
		this.houseNr = houseNr;
		this.postCode = postCode;
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public String getStreet() {
		return street;
	}

	public void setStreet(String street) {
		this.street = street;
	}

	public String getHouseNr() {
		return houseNr;
	}

	public void setHouseNr(String houseNr) {
		this.houseNr = houseNr;
	}

	public String getPostCode() {
		return postCode;
	}

	public void setPostCode(String postCode) {
		this.postCode = postCode;
	}

	@Override
	public String toString() {
		return "Address [city=" + city + ", street=" + street + ", houseNr=" + houseNr + ", postCode=" + postCode + "]";
	}
	
	

}
