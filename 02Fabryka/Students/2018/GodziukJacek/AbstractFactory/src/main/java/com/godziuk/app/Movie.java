/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.app;

/**
 *
 * @author jgodziuk
 */
public abstract class Movie {
    public abstract String getDirector();
    public abstract String getTitle();
    public abstract String getDuration();
    public abstract String getRating();
    public abstract String getLanguage();
    
    @Override 
    public String toString(){
        return  "Director: " + this.getDirector() + "\n" +
                "Title: " + this.getTitle() + "\n" +
                "Duration: " + this.getDuration() + "\n" +
                "Rating: " + this.getRating() + "\n" +
                "Language: " + this.getLanguage() + "\n";
    }
}
