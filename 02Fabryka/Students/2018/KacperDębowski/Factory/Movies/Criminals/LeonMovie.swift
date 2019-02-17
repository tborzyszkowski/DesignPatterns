//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class LeonMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Leon"
        self.productionYear = 1994
        self.rate = 8.13
    }
    
    func name() {
        self.title = "Leon"
    }
    
    func produce() {
        self.productionYear = 1994
    }
    
    func review() {
        self.rate = 8.13
    }
}
