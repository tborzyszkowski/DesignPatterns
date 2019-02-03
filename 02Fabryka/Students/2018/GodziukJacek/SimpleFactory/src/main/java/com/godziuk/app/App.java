package com.godziuk.app;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        MovieFactory movieFactoryInstance = MovieFactory.getInstance();
        Movie horror = movieFactoryInstance.getMovie("Horror", "Jan Nowak", "Straszny film", "123", "8", "ENG");
        System.out.println("Horror movie: \n" + horror.toString() + "\n");
        
        Movie crime = movieFactoryInstance.getMovie("Crime", "Adam Małysz", "Kryminalnie", "88", "4", "PL");
        System.out.println("Crime movie: \n" + crime.toString() + "\n");
    }
}
