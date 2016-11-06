//  Created by Kamil Zielinski on 23/10/16.
//  Copyright © 2016 Kamil Zielinski. All rights reserved.

import Foundation

// 2. fabryka z metodą wytrórczą (patrz pakiet pizzfm)

protocol Car {
    var parts:[String] { get }
    init()
}

class Opel:Car {
    var parts = ["Okrag", "Strzala", "Znaczek"]
    required init() {}
}

class Audi:Car {
    var parts = ["Okrag", "Okrag", "Okrag..."]
    required init() {}
}

protocol CarFactory {
    func create(_ car:Car) -> Car

    func order<T:Car>(_ car:T.Type) -> Car?
}

extension CarFactory {
    func order<T:Car>(_ car:T.Type) -> Car? {
        return create(T())
    }
}

// konkretne metody wytworcze

class GermanyCarFactory: CarFactory {
    func create(_ car:Car) -> Car {
        print("GermanyCarFactory start creating car (\(car)) from:")
        car.parts.reversed().forEach { print($0) }
        print()
        return car
    }
}

class PolandCarFactory: CarFactory {
    func create(_ car:Car) -> Car {
        print("PolandCarFactory start creating car (\(car)) from:")
        car.parts.forEach { print($0) }
        return car
    }
}

_ = GermanyCarFactory().order(Opel.self) // Samochody sa tworzone od tylu
_ = PolandCarFactory().order(Opel.self)

_ = GermanyCarFactory().order(Audi.self)
_ = PolandCarFactory().order(Audi.self)