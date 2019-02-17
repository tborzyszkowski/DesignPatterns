//
//  StarCastAgency.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class StarCastAgency: CastingAgency {
    var catalog: [Actor]

    init() {
        self.catalog = [
            Actor("Nicholas", "Cage", true, 55),
            Actor("Tom", "Hanks", true, 62),
            Actor("Bruce", "Willis", true, 63),
            Actor("Cameron", "Diaz", false, 46),
            Actor("Penelope", "Cruz", false, 44),
            Actor("Jessica", "Alba", false, 37),
        ]
    }

    func castActor() -> Actor {
        return self.catalog[Int.random(in: 0 ..< self.catalog.count)]
    }
}
