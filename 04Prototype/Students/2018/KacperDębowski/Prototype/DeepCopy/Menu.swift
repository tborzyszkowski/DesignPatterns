//
//  Menu.swift
//  Prototype
//
//  Created by Kacper Debowski on 12/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Menu: Codable, Equatable {
    static func == (lhs: Menu, rhs: Menu) -> Bool {
        return lhs.meals == rhs.meals
    }
    
    var meals: [Meal] = []
    
    func addMeal(meal: Meal) {
        self.meals.append(meal)
    }
}
