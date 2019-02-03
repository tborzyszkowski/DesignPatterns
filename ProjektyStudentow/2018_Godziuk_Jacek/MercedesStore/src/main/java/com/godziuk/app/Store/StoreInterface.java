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
public interface StoreInterface {
    public String getAddress();
    public List<Mercedes> getCars();
    public String getSeller();
    
    public void setAddress(String address);
    public void setCars(List<Mercedes> cars);
    public void setSeller(String seller);
}
