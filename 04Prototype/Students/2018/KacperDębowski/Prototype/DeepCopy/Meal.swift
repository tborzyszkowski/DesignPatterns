//
//  Meal.swift
//  Prototype
//
//  Created by Kacper Debowski on 12/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Meal: Codable, Equatable {
    
    static func == (lhs: Meal, rhs: Meal) -> Bool {
        return lhs.ingredients == rhs.ingredients
    }
    
    var ingredients: [String]
    
    init (_ ingredients: [String]) {
        self.ingredients = ingredients
    }
}
