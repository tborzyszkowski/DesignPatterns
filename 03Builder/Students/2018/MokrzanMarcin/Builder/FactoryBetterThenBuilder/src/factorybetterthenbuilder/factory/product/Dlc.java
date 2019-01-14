/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package factorybetterthenbuilder.factory.product;

/**
 *
 * @author Marcin
 */
public abstract class Dlc {
    
    public String productName;
    public String height;
    public String length;
    public String width;
    public String limited;
    
    public String getProductName() {
        return productName;
    }

    public String getWidth() {
        return width;
    }

    public String getHeight() {
        return height;
    }

    public String getLenght() {
        return length;
    }

    public String getLimited() {
        return limited;
    }
    
    @Override
    public String toString() {
        return "Dlc:" + "\n" 
                + "productName = " + productName + "\n"  
                + "Height = " + height + "\n"  
                + "length = " + length + "\n" 
                + "width = " + width + "\n" 
                + "limited = " + limited ;
    }
}
