//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class RosemarysBabyMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Rosemary's Baby"
        self.productionYear = 1968
        self.rate = 7.65
    }
    
    func name() {
        self.title = "Rosemary's Baby"
    }
    
    func produce() {
        self.productionYear = 1968
    }
    
    func review() {
        self.rate = 7.65
    }
    
}
