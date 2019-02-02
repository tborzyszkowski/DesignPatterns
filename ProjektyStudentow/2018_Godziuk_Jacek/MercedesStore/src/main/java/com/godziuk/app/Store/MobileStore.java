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
public class MobileStore {
    private String currentPosition;
    private List<Mercedes> cars;
    private String driver;

    public String getCurrentPosition() {
        return currentPosition;
    }

    public void setCurrentPosition(String currentPosition) {
        this.currentPosition = currentPosition;
    }

    public List<Mercedes> getCars() {
        return cars;
    }

    public void setCars(List<Mercedes> cars) {
        this.cars = cars;
    }

    public String getDriver() {
        return driver;
    }

    public void setDriver(String driver) {
        this.driver = driver;
    }

}
