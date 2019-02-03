//
//  FactoryMethods.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class FMCriminalMovieFactory: FMMovieFactory {
    private static var instance: FMCriminalMovieFactory? = nil
    
    private init() {}
    
    public static func getInstance() -> FMCriminalMovieFactory {
        if self.instance == nil {
            self.instance = FMCriminalMovieFactory()
        }
        return self.instance!
    }
    
    public func createMovie(title: String) -> Movie? {
        var movie: Movie? = nil
        
        switch title {
        case "Se7en":
            movie = SevenMovie()
        case "Leon":
            movie = LeonMovie()
        case "Loving Vincent":
            movie = LovingVincentMovie()
        case "American Gangster":
            movie = AmericanGangsterMovie()
        case "Dirty Harry":
            movie = DirtyHarryMovie()
        default:
            print ("Unknown movie title")
            return nil
        }
        
        return self.prepareMovie(movie: movie!)
    }
    
}
