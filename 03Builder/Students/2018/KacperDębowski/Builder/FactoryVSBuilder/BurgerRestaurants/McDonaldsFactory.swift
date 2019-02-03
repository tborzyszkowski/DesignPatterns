//
//  McDonaldsFactory.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class McDonaldsFactory: BurgerFactory {
    func createBurger(name: String) -> Burger? {
        if name == "BigMac" {
            return BigMacBurger()
        }
        
        if name == "McChicken" {
            return McChickenBurger()
        }
        
        return nil
    }
}
