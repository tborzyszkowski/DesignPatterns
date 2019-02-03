//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class LovingVincentMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Loving Vincent"
        self.productionYear = 2017
        self.rate = 8.12
    }
    
    func name() {
        self.title = "Loving Vincent"
    }
    
    func produce() {
        self.productionYear = 2017
    }
    
    func review() {
        self.rate = 8.12
    }
}
