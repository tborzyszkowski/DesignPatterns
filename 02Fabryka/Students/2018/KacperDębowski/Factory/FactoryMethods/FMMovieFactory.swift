//
//  FMMovieFactory.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

protocol FMMovieFactory {
    func createMovie(title: String) -> Movie?
    func prepareMovie(movie: Movie) -> Movie
}

extension FMMovieFactory {
    internal func prepareMovie(movie: Movie) -> Movie {
        movie.produce()
        movie.name()
        movie.review()
        
        return movie
    }
}
