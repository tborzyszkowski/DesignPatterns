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
public class OnlineStore{
    private String URL;
    private List<Mercedes> cars;
    private String administrator;

    public String getURL() {
        return URL;
    }

    public void setURL(String URL) {
        this.URL = URL;
    }

    public List<Mercedes> getCars() {
        return cars;
    }

    public void setCars(List<Mercedes> cars) {
        this.cars = cars;
    }

    public String getAdministrator() {
        return administrator;
    }

    public void setAdministrator(String administrator) {
        this.administrator = administrator;
    }
    
    
}
