//
//  DeepCopyPrototype.swift
//  Prototype
//
//  Created by Kacper Debowski on 12/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

protocol DeepCopyPrototype: Codable, Equatable {
    associatedtype T: Codable
    func deepCopy() -> T
}

extension DeepCopyPrototype {
    func deepCopy() -> T {
        let jsonEncoder = JSONEncoder()
        let jsonData = try! jsonEncoder.encode(self)
        
        let jsonDecoder = JSONDecoder()
        
        return try! jsonDecoder.decode(T.self, from: jsonData)
    }
}
