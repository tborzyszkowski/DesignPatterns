//
//  main.swift
//  Builder
//
//  Created by Kacper Debowski on 10/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation


//     BUILDER BETTER
let dinner = SundayDinner(builder: HomemadeMealBuilder())

let obiadek = HomemadeMealBuilder()
    .boil(ingredient: "rice")
    .add(ingredient: "chicken")
    .meal

print(dinner.describe())
print(obiadek.describe())


//    FACTORY BETTER
let factory = McDonaldsFactory()
let burger = factory.createBurger(name: "BigMac")

print(burger!.describe())
