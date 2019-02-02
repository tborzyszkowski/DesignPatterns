/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.app.Factory;

/**
 *
 * @author jgodziuk
 */
public class Mercedes implements MercedesInterface{
    private String model;
    private String engine;
    private String type;
    private String price;
    private String warranty;
    
    @Override
    public void setModel(String model) {
        this.model = model;
    }

    @Override
    public void setType(String type) {
        this.type = type;
    }

    @Override
    public void setEngine(String engine) {
        this.engine = engine;
    }

    @Override
    public void setPrice(String price) {
        this.price = price;
    }

    public String getModel() {
        return model;
    }

    public String getEngine() {
        return engine;
    }

    public String getType() {
        return type;
    }

    public String getPrice() {
        return price;
    }

    public String getWarranty() {
        return warranty;
    }

    public void setWarranty(String warranty) {
        this.warranty = warranty;
    }
    
    @Override
    public String toString() {
        return "Mercedes{" + "model=" + model + ", engine=" + engine + ", type=" + type + ", price=" + price + ", warranty=" + warranty + '}';
    }


    
    
}
