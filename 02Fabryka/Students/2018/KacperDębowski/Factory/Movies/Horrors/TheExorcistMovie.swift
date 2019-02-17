//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class TheExorcistMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "The Exorcist"
        self.productionYear = 1973
        self.rate = 7.52
    }
    
    func name() {
        self.title = "The Exorcist"
    }
    
    func produce() {
        self.productionYear = 1973
    }
    
    func review() {
        self.rate = 7.52
    }
    
}
