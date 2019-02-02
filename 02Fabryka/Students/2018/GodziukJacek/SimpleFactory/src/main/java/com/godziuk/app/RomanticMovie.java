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
public class RomanticMovie extends Movie {

    private String director;
    private String title;
    private String duration;
    private String rating;
    private String language;

    public RomanticMovie(String director, String title, String duration, String rating, String language) {
        this.director = director;
        this.title = title;
        this.duration = duration;
        this.rating = rating;
        this.language = language;
    }

    @Override
    public String getDirector() {
        return this.director;
    }

    @Override
    public String getTitle() {
        return this.title;
    }

    @Override
    public String getDuration() {
        return this.duration;
    }

    @Override
    public String getRating() {
        return this.rating;
    }

    @Override
    public String getLanguage() {
        return this.language;
    }

}
