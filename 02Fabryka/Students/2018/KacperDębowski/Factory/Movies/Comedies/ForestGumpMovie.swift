//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class ForestGumpMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "Forest Gump"
        self.productionYear = 1995
        self.rate = 8.54
    }
    
    public func name() {
        self.title = "Forest Gump"
    }
    
    public func produce() {
        self.productionYear = 1995
    }
    
    public func review() {
        self.rate = 8.54
    }
}
