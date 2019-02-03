/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.app.Employee;

/**
 *
 * @author jgodziuk
 */
public class Employee {
    private String name;
    private boolean isWorkingNow = false;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public boolean isIsWorkingNow() {
        return isWorkingNow;
    }

    public void setIsWorkingNow(boolean isWorkingNow) {
        this.isWorkingNow = isWorkingNow;
    }
    
    public void setIsWorkingNowToTrue(){
        this.isWorkingNow = true;
    }

    @Override
    public String toString() {
        return "Employee{" + "name=" + name + ", isWorkingNow=" + isWorkingNow + '}';
    }
    
    
}
