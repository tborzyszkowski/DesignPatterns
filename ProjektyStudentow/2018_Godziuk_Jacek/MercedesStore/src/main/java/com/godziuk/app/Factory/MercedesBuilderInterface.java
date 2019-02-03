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
public interface MercedesBuilderInterface {
    public void buildMercedsModel();
    public void buildMercedesType();
    public void buildMercedesEngine();
    public void buildMercedesPrice();
    
    public Mercedes getMercedes();
}
