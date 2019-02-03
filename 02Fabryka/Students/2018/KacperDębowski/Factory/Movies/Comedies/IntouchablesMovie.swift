//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class IntouchablesMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Intouchables"
        self.productionYear = 2011
        self.rate = 8.68
    }
    
    public func name() {
        self.title = "Intouchables"
    }
    
    public func produce() {
        self.productionYear = 2011
    }
    
    public func review() {
        self.rate = 8.68
    }
}
