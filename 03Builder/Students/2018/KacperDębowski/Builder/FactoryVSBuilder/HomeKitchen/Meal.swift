//
//  Meal.swift
//  Builder
//
//  Created by Kacper Debowski on 11/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Meal {
    var mainCourse: [String] = []
    var sideDish: String = ""
    var additions: [String] = []
    
    init () {}
    
    init (copyFrom: Meal) {
        mainCourse = copyFrom.mainCourse
        sideDish = copyFrom.sideDish
        additions = copyFrom.additions
    }
    
    convenience init (builder: MealBuilder) {
        self.init (copyFrom: builder.meal)
    }
    
    func describe() -> String {
        var description = ""
        
        for course in mainCourse {
            if description.count > 0 {
                description += ", "
            }
            description += course
        }
        
        if additions.count > 0 {
            for addition in additions {
                description += " with " + addition + " and"
            }
        }
        
        if sideDish != "" {
            description += " served with " + sideDish + " on the side"
        }
            
        else {
            description.removeLast(4)
        }
        
        return description
    }
}
