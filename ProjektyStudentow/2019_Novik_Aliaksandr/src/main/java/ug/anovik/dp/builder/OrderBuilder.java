package ug.anovik.dp.builder;

import java.time.LocalDate;
import java.util.Map;

import ug.anovik.dp.MobileDevice;

public class OrderBuilder {

	private int orderId;
	private Company company;
	private Map<MobileDevice, Integer> orderList;
	private LocalDate orderDate;
	private boolean isVATrequired;
	
	public OrderBuilder setRequeredFields(int orderId, Company company, Map<MobileDevice, Integer> orderList) {
		this.orderId = orderId;
		this.company = company;
		this.orderList = orderList;
		return this;
	}
	
	public OrderBuilder setOrderDate() {
		this.orderDate = LocalDate.now();
		return this;
	}
	
	public OrderBuilder setVATrequired(boolean isVATrequired) {
		this.isVATrequired = isVATrequired;
		return this;
	}
	
	public Order build() {
		Order order = new Order();
		order.setRequiredFields(orderId, company, orderList);
		order.setOrderDate();
		order.setVATrequired(isVATrequired);
		return order;
	}
	
}
