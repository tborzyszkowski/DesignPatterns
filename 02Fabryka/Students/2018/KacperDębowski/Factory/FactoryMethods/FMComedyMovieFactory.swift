//
//  FactoryMethods.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class FMComedyMovieFactory: FMMovieFactory {
    private static var instance: FMComedyMovieFactory? = nil
    
    private init() {}
    
    public static func getInstance() -> FMComedyMovieFactory {
        if self.instance == nil {
            self.instance = FMComedyMovieFactory()
        }
        return self.instance!
    }
    
    public func createMovie(title: String) -> Movie? {
        var movie: Movie? = nil
        
        switch title {
        case "Forest Gump":
            movie = ForestGumpMovie()
        case "Monty Python and the Holy Grail":
            movie = HolyGrailMovie()
        case "Kiler":
            movie = KilerMovie()
        case "The Bucket List":
            movie = TheBucketListMovie()
        case "Intouchables":
            movie = IntouchablesMovie()
        default:
            print ("Unknown movie title")
            return nil
        }

        return self.prepareMovie(movie: movie!)
    }
    
}
