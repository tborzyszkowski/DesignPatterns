//
//  HomemadeMealBuilder.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class HomemadeMealBuilder: MealBuilder {
    var meal: Meal
    
    init() {
        meal = Meal()
    }

    func bake(ingredient: String) -> MealBuilder {
        meal.mainCourse.append("home-baked " + ingredient)
        return self
    }
    
    func fry(ingredient: String) -> MealBuilder {
        meal.mainCourse.append("home-fried " + ingredient)
        return self
    }
    
    func boil(ingredient: String) -> MealBuilder {
        meal.mainCourse.append("home-boiled " + ingredient)
        return self
    }
    
    func add(ingredient: String) -> MealBuilder {
        meal.additions.append("fresh " + ingredient)
        return self
    }
    
    func sidedish(sidedish: String) -> MealBuilder {
        meal.sideDish = "home-made " + sidedish
        return self
    }
    
    
}
