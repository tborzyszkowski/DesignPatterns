//
//  IntouchablesMovie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class TheBucketListMovie: Movie {
    var title: String
    var productionYear: Int
    var rate: Double
    
    required init() {
        self.title = "The Bucket List"
        self.productionYear = 2007
        self.rate = 7.63
    }
    
    public func name() {
        self.title = "The Bucket List"
    }
    
    public func produce() {
        self.productionYear = 2007
    }
    
    public func review() {
        self.rate = 7.63
    }
}
