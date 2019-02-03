//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class AlienMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Alien"
        self.productionYear = 1979
        self.rate = 7.84
    }
    
    func name() {
        self.title = "Alien"
    }
    
    func produce() {
        self.productionYear = 1979
    }
    
    func review() {
        self.rate = 7.84
    }
    
}
