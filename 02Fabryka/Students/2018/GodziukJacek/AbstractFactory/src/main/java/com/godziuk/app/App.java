package com.godziuk.app;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        Movie horror = MovieFactory.getMovie(new HorrorMovieFactory("Jan Nowak", "Straszny film", "123", "8", "ENG"));
        Movie comedy = MovieFactory.getMovie(new ComedyMovieFactory("Julia Sęk", "Wesołe Święta", "130", "4", "PL"));

        System.out.println("Horror movie: \n" + horror.toString() + "\n");
        System.out.println("Comedy movie: \n" + comedy.toString() + "\n");
    }
}
