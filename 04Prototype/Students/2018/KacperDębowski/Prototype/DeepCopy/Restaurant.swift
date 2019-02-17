//
//  Restaurant.swift
//  Prototype
//
//  Created by Kacper Debowski on 12/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Restaurant: DeepCopyPrototype {
    static func == (lhs: Restaurant, rhs: Restaurant) -> Bool {
        return lhs.address == rhs.address && lhs.menu == rhs.menu
    }
    
    typealias T = Restaurant
    
    var address: String
    var menu: Menu
    
    init(_ address: String, _ menu: Menu) {
        self.address = address
        self.menu = menu
    }
}
