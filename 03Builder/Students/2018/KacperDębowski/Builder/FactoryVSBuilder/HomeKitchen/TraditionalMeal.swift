//
//  TraditionalMeal.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class SundayDinner: Meal {
    convenience init (builder: MealBuilder) {
        self.init(copyFrom:
            builder
            .fry(ingredient: "pork")
            .bake(ingredient: "potatoes")
            .add(ingredient: "pepper")
            .sidedish(sidedish: "bigos")
            .meal)
    }
}
