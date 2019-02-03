//
//  NetflixMovie.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class NetflixMovie: Movie {
    init (wrappedMovie: Movie) {
        super.init(wrappedMovie.title, wrappedMovie.star, wrappedMovie.genre)
        sequel = wrappedMovie.sequel
        price = wrappedMovie.price
        description = wrappedMovie.description
    }
    
    func getExtendedDescription() -> String {
        return description + "... Only on Netflix!"
    }
    
    func availableLanguages() -> String {
        return "Polish, English, German, French"
    }
}
