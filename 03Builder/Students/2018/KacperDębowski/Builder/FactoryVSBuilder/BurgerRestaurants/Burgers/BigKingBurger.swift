//
//  BigKingBurger.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class BigKingBurger: Burger {
    var typeOfMeat: String
    var meatPieces: Int
    var veggies: [String]
    var sauce: String
    var cheese: Bool
    var price: Float
    
    init() {
        self.typeOfMeat = "beef"
        self.meatPieces = 2
        self.veggies = ["salad", "onion", "pickle"]
        self.sauce = "special Big King sauce"
        self.cheese = true
        self.price = 11.95
    }
}
