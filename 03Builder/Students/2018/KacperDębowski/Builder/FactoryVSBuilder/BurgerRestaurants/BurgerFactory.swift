//
//  BurgerFactor.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

protocol BurgerFactory {
    func createBurger(name: String) -> Burger?
}
