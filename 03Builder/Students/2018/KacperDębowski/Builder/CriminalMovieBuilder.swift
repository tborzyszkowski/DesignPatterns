//
//  CriminalMovieBuilder.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class CriminalMovieBuilder: MovieBuilder {
    var movie: Movie
    
    init() {
        self.movie = Movie()
    }
    
    func nameMovie() -> MovieBuilder {
        self.movie.title = "Dirty Harry"
        return self
    }
    
    func doCasting() -> MovieBuilder {
        self.movie.star = "Clint Eastwood"
        return self
    }
    
    func directMovie() -> MovieBuilder {
        self.movie.genre = "Criminal"
        return self
    }
    
    func releaseMovie() -> MovieBuilder {
        self.movie.boxOffice = 36000000
        return self
    }
    
    func rateMovie() -> MovieBuilder {
        self.movie.rating = 7.7
        return self
    }
    
    
}
