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
public class MobileStoreAdapter implements StoreInterface{
    
    MobileStore mobileStore;
    
    public MobileStoreAdapter(MobileStore mobileStore){
        this.mobileStore = mobileStore;
    }

    @Override
    public String getAddress() {
        return mobileStore.getCurrentPosition();
    }

    @Override
    public List<Mercedes> getCars() {
        return mobileStore.getCars();
    }

    @Override
    public String getSeller() {
        return mobileStore.getDriver();
    }

    @Override
    public void setAddress(String address) {
        mobileStore.setCurrentPosition(address);
    }

    @Override
    public void setCars(List<Mercedes> cars) {
        mobileStore.setCars(cars);
    }

    @Override
    public void setSeller(String seller) {
        mobileStore.setDriver(seller);
    }
    
    
}
