//
//  Burger.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

protocol Burger {
    var typeOfMeat: String { get set }
    var meatPieces: Int{ get set }
    var veggies: [String]{ get set }
    var sauce: String{ get set }
    var cheese: Bool{ get set }
    var price: Float{ get set }
}

extension Burger {
    func describe() -> String {
        var description = "Burger with " + String(meatPieces) + " piece(s) of " + typeOfMeat + ", "
        
        if cheese {
            description.append("cheese")
        }
        
        description.append(" and with fresh ")
        
        for veggie in veggies {
            description.append(veggie + ", ")
        }
        
        description.append(" with addition of " + sauce + " for just " + String(price) + "!")
        
        return description
    }
}
