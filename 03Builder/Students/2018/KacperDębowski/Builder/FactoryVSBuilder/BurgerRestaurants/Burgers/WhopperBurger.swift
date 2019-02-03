//
//  WhopperBurger.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class WhopperBurger: Burger {
    var typeOfMeat: String
    var meatPieces: Int
    var veggies: [String]
    var sauce: String
    var cheese: Bool
    var price: Float
    
    init() {
        typeOfMeat = "beef"
        meatPieces = 1
        veggies = ["salad", "tomato", "onion", "pickles"]
        sauce = "mayo & ketchup"
        cheese = false
        price = 13.95
    }
}
