//
//  Actor.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Actor {
    public let name: String
    public let lastName: String
    public let male: Bool
    public let age: Int
    
    init(_ name: String, _ lastName: String, _ male: Bool, _ age: Int) {
        self.name = name
        self.lastName = lastName
        self.male = male
        self.age = age
    }
}
