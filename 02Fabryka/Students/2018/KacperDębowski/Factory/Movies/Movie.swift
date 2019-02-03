//
//  Movie.swift
//  Factory
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

protocol Movie {
    var title: String {get set}
    var productionYear: Int {get set}
    var rate: Double {get set}
    
    func name() -> Void
    func produce() -> Void
    func review() -> Void
}
