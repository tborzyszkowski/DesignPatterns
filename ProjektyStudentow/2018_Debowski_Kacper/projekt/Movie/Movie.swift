//
//  Movie.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Movie: Prototype {
    var title: String
    var star: Actor
    var genre: String
    var sequel: Bool = false
    var price: Int = 0
    var description: String = ""
    
    init (_ title: String, _ star: Actor, _ genre: String) {
        self.title = title
        self.star = star
        self.genre = genre
    }
    
    func clone() -> Prototype {
        let movie = Movie(self.title, self.star, self.genre)
        movie.sequel = self.sequel

        return movie
    }

    func getDescription() {
    }
}
