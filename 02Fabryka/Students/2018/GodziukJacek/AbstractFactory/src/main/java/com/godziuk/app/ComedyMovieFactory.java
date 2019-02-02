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
public class ComedyMovieFactory implements MovieAbstractFactory{
    private String director;
    private String title;
    private String duration;
    private String rating;
    private String language;

    public ComedyMovieFactory(String director, String title, String duration, String rating, String language) {
        this.director = director;
        this.title = title;
        this.duration = duration;
        this.rating = rating;
        this.language = language;
    }
    
    @Override
    public Movie createMovie() {
        return new ComedyMovie(director, title, duration, rating, language);
    }
    
}
