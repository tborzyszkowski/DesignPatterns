//
//  BigMacBurger.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class BigMacBurger: Burger {
    var typeOfMeat: String
    var meatPieces: Int
    var veggies: [String]
    var sauce: String
    var cheese: Bool
    var price: Float
    
    init() {
        typeOfMeat = "beef"
        meatPieces = 2
        veggies = ["salad", "pickle", "chopped onion"]
        sauce = "special Big Mac sauce"
        cheese = true
        price = 9.70
    }
}
