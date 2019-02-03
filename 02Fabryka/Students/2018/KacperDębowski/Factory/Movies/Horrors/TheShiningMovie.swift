//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class TheShiningMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "The Shining"
        self.productionYear = 1980
        self.rate = 7.72
    }
    
    func name() {
        self.title = "The Shining"
    }
    
    func produce() {
        self.productionYear = 1980
    }
    
    func review() {
        self.rate = 7.72
    }
    
}
