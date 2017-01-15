//
//  PizzaBuilder.swift
//  ProjetWzorce-GithubViewer
//
//  Created by Kamil Zielinski on 15/01/2017.
//  Copyright © 2017 Kamil Zielinski. All rights reserved.
//

import Foundation

class PizzaBuilder {
    private var pizza = Pizza()

    func set(name: String) -> PizzaBuilder {
        pizza.name = name
        return self
    }

    func set(ciasto: Ciasto) -> PizzaBuilder {
        pizza.ciasto = ciasto
        return self
    }

    func add(skladniki: [String]) -> PizzaBuilder {
        if pizza.skladniki == nil {
            pizza.skladniki = skladniki
        } else {
            pizza.skladniki?.append(contentsOf: skladniki)
        }

        return self
    }

    func getPizza() -> Pizza {
        return pizza
    }
}
