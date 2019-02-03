//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class HolyGrailMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Monty Python and the Holy Grail"
        self.productionYear = 1975
        self.rate = 8.01
    }
    
    public func name() {
        self.title = "Monty Python and the Holy Grail"
    }
    
    public func produce() {
        self.productionYear = 1975
    }
    
    public func review() {
        self.rate = 8.01
    }
}
