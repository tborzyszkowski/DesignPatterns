//  Created by Kamil Zielinski on 23/10/16.
//  Copyright © 2016 Kamil Zielinski. All rights reserved.

import Foundation

// Generyczna [abstrakcyjna] fabryka

/**
 Protokol dla abstrakcyjnej fabryki ( nie mozna podac typu <> ) ! przez co nie mozna stworzyc zmiennej typu tego protokolu tj:

 var absFac:AbstractFactory <- kompilator nie pozowli na cos takiego bo AbstractFactory musi miec powiazany typ (associatedtype)
 */
protocol AbstractFactory {
    associatedtype Product
    func createProduct() -> Product
}

// Protokol ktory wymusza bezargumentowy konstruktor
protocol Initable {
    init()
}

// Dwa Produkty
class Plates: Initable { required init() {} }
class Glass: Initable { required init() {} }

// Jedna klasa (fabryka) ktora moze produkowac rozne produkty ktore adoptuja Initable protokol
class Generic<T: Initable>: AbstractFactory { // Typ T musi implementowac Initable
    typealias Product = T // AbstractFactory wymaga zdefiniowania *associatedtype*. W tym miejscu to robimy

    internal func createProduct() -> Product {
        return Product()
    }
}

let platesFabric = Generic<Plates>()
print(platesFabric.createProduct()) // Fabrics.Plates

let glassFabric = Generic<Glass>()
print(glassFabric.createProduct()) // Fabrics.Glass
