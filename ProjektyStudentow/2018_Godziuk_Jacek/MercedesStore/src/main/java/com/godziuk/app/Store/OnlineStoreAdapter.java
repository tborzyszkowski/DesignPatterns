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
public class OnlineStoreAdapter implements StoreInterface{

    OnlineStore onlineStore;
    
    public OnlineStoreAdapter(OnlineStore onlineStore){
        this.onlineStore = onlineStore;
    }

    @Override
    public String getAddress() {
        return onlineStore.getURL();
    }

    @Override
    public List<Mercedes> getCars() {
        return onlineStore.getCars();
    }

    @Override
    public String getSeller() {
        return onlineStore.getAdministrator();
    }

    @Override
    public void setAddress(String address) {
        onlineStore.setURL(address);
    }

    @Override
    public void setCars(List<Mercedes> cars) {
        onlineStore.setCars(cars);
    }

    @Override
    public void setSeller(String seller) {
        onlineStore.setAdministrator(seller);
    }

    
    
}
