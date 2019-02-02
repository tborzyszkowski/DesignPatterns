/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.app.Company;

import com.godziuk.app.Store.Store;
import com.godziuk.app.Store.StoreInterface;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author jgodziuk
 */
public class Company {
    private static Company instance = null;
    private String name;
    private List<StoreInterface> stores = new ArrayList<>();
    
    public Company(){
        System.out.println("\nComapny has been created!\n");
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<StoreInterface> getStores() {
        return stores;
    }

    public void setStores(List<StoreInterface> stores) {
        this.stores = stores;
    }

    @Override
    public String toString() {
        return "Company{" + "name=" + name + ", stores=" + stores + '}';
    }


    
    
    public static Company getInstance(){
        if(instance == null){
            instance = new Company();
        }
        return instance;
    }
}
