//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class DirtyHarryMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Dirty Harry"
        self.productionYear = 1971
        self.rate = 7.71
    }
    
    func name() {
        self.title = "Dirty Harry"
    }
    
    func produce() {
        self.productionYear = 1971
    }
    
    func review() {
        self.rate = 7.71
    }
}
