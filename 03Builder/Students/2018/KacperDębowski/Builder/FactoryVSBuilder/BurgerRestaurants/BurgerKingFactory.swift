//
//  BurgerKingFactory.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class BurgerKingFactory: BurgerFactory {
    func createBurger(name: String) -> Burger? {
        if name == "Whopper" {
            return WhopperBurger()
        }
        
        if name == "Big King" {
            return BigKingBurger()
        }
        return nil
    }
}
