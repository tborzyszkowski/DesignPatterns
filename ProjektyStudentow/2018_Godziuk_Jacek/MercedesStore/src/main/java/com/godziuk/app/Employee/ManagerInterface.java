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
public interface ManagerInterface{
    
    public void attach(Employee e);
    public void detach(Employee e);
    public void notifyEmployees();
    
}
