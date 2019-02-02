/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.app.Employee;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author jgodziuk
 */
public class Manager implements ManagerInterface{
    
    List<Employee> observers;
    
    public Manager() {
        observers = new ArrayList<>();
    }

    @Override
    public void attach(Employee e) {
        observers.add(e);
    }

    @Override
    public void detach(Employee e) {
        observers.remove(e);
    }

    @Override
    public void notifyEmployees() {
        for(Employee e : observers){
            e.setIsWorkingNowToTrue();
        }
    }
    
    
    
}
