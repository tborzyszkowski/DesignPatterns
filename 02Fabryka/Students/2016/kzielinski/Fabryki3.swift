//  Created by Kamil Zielinski on 23/10/16.
//  Copyright © 2016 Kamil Zielinski. All rights reserved.

import Foundation

// Przyklad rejestracji dostepnych produkcji fabryki i proby ich stworzenia

protocol Item { init() }

struct Chair : Item {}
struct Window : Item {}

class Shop {
    var avaiableShoes: [Item.Type] = []

    func register(shoeType: Item.Type) {
        avaiableShoes.append(shoeType)
    }

    func get(shoeType: Item.Type) -> Item? {
        if avaiableShoes.contains(where: { $0 == shoeType }) {
            return shoeType.init()
        }
        return nil
    }
}

let shop1 = Shop()
let shop2 = Shop()

shop1.register(shoeType: Chair.self)
shop2.register(shoeType: Window.self)

if let chair = shop1.get(shoeType: Chair.self) { print("got Chair from shop1") }
if let window = shop1.get(shoeType: Window.self) { print("got Window from shop1") }

if let chair = shop2.get(shoeType: Chair.self) { print("got Chair from shop2") }
if let window = shop2.get(shoeType: Window.self) { print("got Window from shop2") }