//
//  Movie.swift
//  Prototype
//
//  Created by Kacper Debowski on 12/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Movie: MoviePrototype {
    private var title: String
    private var star: String
    private var date: Int
    
    init (_ title: String, _ star: String, _ date: Int) {
        self.title = title
        self.star = star
        self.date = date
    }
    
    convenience init (copyFrom: Movie) {
        self.init(copyFrom.title, copyFrom.star, copyFrom.date)
    }
    
    func clone() -> MoviePrototype {
        return Movie(copyFrom: self)
    }
    
    func describe() -> String {
        return "Movie '" + title + "' from " + String(date) + " starring " + star + "!"
    }
    
}
