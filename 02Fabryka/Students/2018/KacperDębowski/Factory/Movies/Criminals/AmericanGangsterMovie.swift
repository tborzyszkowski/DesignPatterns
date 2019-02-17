//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class AmericanGangsterMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "American Gangster"
        self.productionYear = 2007
        self.rate = 7.81
    }
    
    func name() {
        self.title = "American Gangster"
    }
    
    func produce() {
        self.productionYear = 2007
    }
    
    func review() {
        self.rate = 7.81
    }
}
