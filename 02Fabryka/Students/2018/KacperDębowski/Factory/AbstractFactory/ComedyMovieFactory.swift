//
//  ComedyMovieFactory.swift
//  Factory
//
//  Created by Kacper Debowski on 10/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class ComedyMovieFactory: AbstractMovieFactory {
    func createMovie(title: String) -> Movie? {
        if title.lowercased() == "Forest Gump".lowercased() {
            return ForestGumpMovie()
        }
        if title.lowercased() == "Holy Grail".lowercased() {
            return HolyGrailMovie()
        }
        if title.lowercased() == "Kiler".lowercased() {
            return KilerMovie()
        }
        if title.lowercased() == "The Bucket List".lowercased() {
            return TheBucketListMovie()
        }
        if title.lowercased() == "Intouchables".lowercased() {
            return IntouchablesMovie()
        }
        
        return nil
    }
}
