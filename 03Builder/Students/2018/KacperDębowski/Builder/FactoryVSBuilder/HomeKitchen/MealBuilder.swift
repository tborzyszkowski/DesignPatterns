//
//  MealBuilder.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

protocol MealBuilder {
    var meal: Meal { get }
    func bake (ingredient: String) -> MealBuilder
    func fry (ingredient: String) -> MealBuilder
    func boil (ingredient: String) -> MealBuilder
    func add (ingredient: String) -> MealBuilder
    func sidedish (sidedish: String) -> MealBuilder
}
