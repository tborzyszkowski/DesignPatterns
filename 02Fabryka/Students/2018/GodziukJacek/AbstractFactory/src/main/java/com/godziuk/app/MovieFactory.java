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
    public static Movie getMovie(MovieAbstractFactory factory) {
        return factory.createMovie();
    }
}
