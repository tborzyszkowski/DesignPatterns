//
//  CinemaMovie.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class CinemaMovie: Movie {

    init (wrappedMovie: Movie) {
        super.init(wrappedMovie.title, wrappedMovie.star, wrappedMovie.genre)
        sequel = wrappedMovie.sequel
        price = wrappedMovie.price
        description = wrappedMovie.description
    }
    
    func getTicketPrice() -> Int {
        return 25
    }
    
    func getScreeningHours() -> String {
        return "15:30, 17:30, 19:00, 19:30, 20:45, 21:15, 22:00"
    }
}
