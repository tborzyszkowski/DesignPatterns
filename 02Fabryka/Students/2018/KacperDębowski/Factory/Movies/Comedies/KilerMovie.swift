//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class KilerMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Kiler"
        self.productionYear = 1997
        self.rate = 7.47
    }
    
    public func name() {
        self.title = "Kiler"
    }
    
    public func produce() {
        self.productionYear = 1997
    }
    
    public func review() {
        self.rate = 7.47
    }
}
