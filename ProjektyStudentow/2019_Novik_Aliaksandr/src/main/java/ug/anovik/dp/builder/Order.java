package ug.anovik.dp.builder;

import java.time.LocalDate;
import java.util.Map;

import ug.anovik.dp.MobileDevice;

public class Order {

	private int orderId;
	private Company company;
	private Map<MobileDevice, Integer> orderList;
	private LocalDate orderDate;
	private boolean isVATrequired;

	public void setRequiredFields(int orderId, Company company, Map<MobileDevice, Integer> orderList) {
		this.orderId = orderId;
		this.company = company;
		this.orderList = orderList;
	}
	
	public void setOrderId(int orderId) {
		this.orderId = orderId;
	}


	public void setCompany(Company company) {
		this.company = company;
	}


	public void setOrderList(Map<MobileDevice, Integer> orderList) {
		this.orderList = orderList;
	}


	public void setOrderDate() {
		this.orderDate = LocalDate.now();
	}


	public void setVATrequired(boolean isVATrequired) {
		this.isVATrequired = isVATrequired;
	}


	@Override
	public String toString() {
		return "Order [orderId=" + orderId + ", company=" + company + ", orderList=" + orderList + ", orderDate="
				+ orderDate + ", isVATrequired=" + isVATrequired + "]";
	}
}
