//
//  CastingAgency.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

protocol CastingAgency {
    var catalog: [Actor] {get set}
    
    func castActor() -> Actor
}
