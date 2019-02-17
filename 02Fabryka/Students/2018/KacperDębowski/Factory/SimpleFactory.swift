//
//  SimpleFactory.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class MovieFactory {
    private static var instance: MovieFactory? = nil
    
    static func getInstance() -> MovieFactory {
        if self.instance == nil {
            instance = MovieFactory()
        }
        return self.instance!
    }
    
    public func createMovie(genre: String) -> Movie? {
        switch genre.lowercased() {
        case "comedy":
            return IntouchablesMovie()
        case "criminal":
            return DirtyHarryMovie()
        case "horror":
            return DraculaMovie()
        default:
            print("Unknown movie genre")
            return nil
        }
    }
    
}
