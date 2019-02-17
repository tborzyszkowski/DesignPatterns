//
//  McChickenBurger.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class McChickenBurger: Burger {
    var typeOfMeat: String
    var meatPieces: Int
    var veggies: [String]
    var sauce: String
    var cheese: Bool
    var price: Float
    
    init() {
        typeOfMeat = "chicken"
        meatPieces = 1
        veggies = ["salad"]
        sauce = "mayo"
        cheese = false
        price = 8.90
    }
}
