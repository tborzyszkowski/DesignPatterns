//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class DraculaMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Dracula"
        self.productionYear = 1992
        self.rate = 7.54
    }
    
    func name() {
        self.title = "Dracula"
    }
    
    func produce() {
        self.productionYear = 1992
    }
    
    func review() {
        self.rate = 7.54
    }
    
}
