//
//  CriminalMovieFactory.swift
//  Factory
//
//  Created by Kacper Debowski on 10/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class CriminalMovieFactory: AbstractMovieFactory {
    
    func createMovie(title: String) -> Movie? {
        if title.lowercased() == "Seven".lowercased() {
            return SevenMovie()
        }
        if title.lowercased() == "Leon".lowercased() {
            return LeonMovie()
        }
        if title.lowercased() == "Loving Vincent".lowercased() {
            return LovingVincentMovie()
        }
        if title.lowercased() == "American Gangster".lowercased() {
            return AmericanGangsterMovie()
        }
        if title.lowercased() == "Dirty Harry".lowercased() {
            return DirtyHarryMovie()
        }
        
        return nil
    }
}
