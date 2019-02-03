//
//  Movie.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Movie {
    var title: String = ""
    var star: String = ""
    var genre: String = ""
    var rating: Float = 0
    var boxOffice: Int32 = 0
    
    init() {}
    
    init(copyFrom: Movie) {
        self.title = copyFrom.title
        self.star = copyFrom.star
        self.genre = copyFrom.genre
        self.rating = copyFrom.rating
        self.boxOffice = copyFrom.boxOffice
    }
}
