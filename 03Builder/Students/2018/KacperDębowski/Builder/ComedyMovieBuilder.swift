//
//  ComedyMovieBuilder.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class ComedyMovieBuilder: MovieBuilder {
    var movie: Movie
    
    init() {
        self.movie = Movie()
    }
    
    func nameMovie() -> MovieBuilder {
        self.movie.title = "Forest Gump"
        return self
    }
    
    func doCasting() -> MovieBuilder {
        self.movie.star = "Tom Hanks"
        return self
    }
    
    func directMovie() -> MovieBuilder {
        self.movie.genre = "Comedy"
        return self
    }
    
    func releaseMovie() -> MovieBuilder {
        self.movie.boxOffice = 677900000
        return self
    }
    
    func rateMovie() -> MovieBuilder {
        self.movie.rating = 8.5
        return self
    }
    
    
}
