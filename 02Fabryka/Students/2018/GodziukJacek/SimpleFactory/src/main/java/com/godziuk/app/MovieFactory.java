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
public class MovieFactory {
    private static MovieFactory instance = null;
    
    public static MovieFactory getInstance(){
        if(instance == null){
            instance = new MovieFactory(); 
        }
        return instance;
    }
    
    public Movie getMovie(String type, String director, String title, String duration, String rating, String language){
        switch(type){
            case "Horror":
                return new HorrorMovie(director, title, duration, rating, language);
            case "Comedy":
                return new ComedyMovie(director, title, duration, rating, language);
            case "Romantic":
                return new RomanticMovie(director, title, duration, rating, language);
            case "Crime":
                return new CrimeMovie(director, title, duration, rating, language);
            default:
                return null;
        }
    }
}
