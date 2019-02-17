//
//  HorrorMovieFactory.swift
//  Factory
//
//  Created by Kacper Debowski on 10/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class HorrorMovieFactory: AbstractMovieFactory {
    
    func createMovie(title: String) -> Movie? {
        if title.lowercased() == "Alien".lowercased() {
            return AlienMovie()
        }
        if title.lowercased() == "Dracula".lowercased() {
            return DraculaMovie()
        }
        if title.lowercased() == "Rosemary\'s Baby".lowercased() {
            return RosemarysBabyMovie()
        }
        if title.lowercased() == "The Shining".lowercased() {
            return TheShiningMovie()
        }
        if title.lowercased() == "The Exorcist".lowercased() {
            return TheExorcistMovie()
        }
        
        return nil
    }
}
