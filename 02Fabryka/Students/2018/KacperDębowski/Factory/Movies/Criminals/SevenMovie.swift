//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class SevenMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Se7en"
        self.productionYear = 1995
        self.rate = 8.30
    }
    
    func name() {
        self.title = "Se7en"
    }
    
    func produce() {
        self.productionYear = 1995
    }
    
    func review() {
        self.rate = 8.30
    }
}
