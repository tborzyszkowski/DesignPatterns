//
//  MovieBuilder.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

protocol MovieBuilder {
    var movie: Movie { get }
    
    func nameMovie() -> MovieBuilder
    func doCasting() -> MovieBuilder
    func directMovie() -> MovieBuilder
    func releaseMovie() -> MovieBuilder
    func rateMovie() -> MovieBuilder
}

extension Movie {
    convenience init(_ builder: MovieBuilder) {
        self.init(copyFrom: builder.nameMovie()
            .doCasting()
            .directMovie()
            .releaseMovie()
            .rateMovie().movie)
    }
}
