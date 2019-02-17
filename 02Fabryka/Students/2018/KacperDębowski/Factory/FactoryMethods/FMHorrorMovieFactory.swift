//
//  FactoryMethods.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class FMHorrorMovieFactory: FMMovieFactory {
    private static var instance: FMHorrorMovieFactory? = nil
    
    private init() {}
    
    public static func getInstance() -> FMHorrorMovieFactory {
        if self.instance == nil {
            self.instance = FMHorrorMovieFactory()
        }
        return self.instance!
    }
    
    public func createMovie(title: String) -> Movie? {
        var movie: Movie? = nil
        
        switch title {
        case "Alien":
            movie = AlienMovie()
            break
        case "Dracula":
            movie = DraculaMovie()
            break
        case "Rosemary\'s Baby":
            movie = RosemarysBabyMovie()
            break
        case "The Shining":
            movie = TheShiningMovie()
            break
        case "The Exorcist":
            movie = TheShiningMovie()
            break
        default:
            print ("Unknown movie title")
            return nil
        }
        
        return self.prepareMovie(movie: movie!)
    }
    
}
