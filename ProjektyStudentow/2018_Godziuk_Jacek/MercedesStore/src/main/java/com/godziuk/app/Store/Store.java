/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.app.Store;

import com.godziuk.app.Factory.Mercedes;
import java.util.List;
/**
 *
 * @author jgodziuk
 */
public class Store implements StoreInterface {
    private String address;
    private List<Mercedes> cars;
    private String seller;

    @Override
    public String getAddress() {
        return this.address;
    }

    @Override
    public List<Mercedes> getCars() {
        return this.cars;
    }

    @Override
    public String getSeller() {
        return this.seller;
    }

    @Override
    public void setAddress(String address) {
        this.address = address;
    }

    @Override
    public void setCars(List<Mercedes> cars) {
        this.cars = cars;
    }

    @Override
    public void setSeller(String seller) {
        this.seller = seller;
    }
    
    
}
