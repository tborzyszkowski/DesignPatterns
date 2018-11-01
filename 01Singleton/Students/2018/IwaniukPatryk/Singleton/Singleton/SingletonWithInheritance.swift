//
//  SingletonWithInheritance.swift
//  Singleton
//
//  Created by Patryk Iwaniuk on 01/11/2018.
//  Copyright © 2018 Patryk Iwaniuk. All rights reserved.
//
import Foundation

class SingletonBase: NSObject {
    
    var property = ""
    
    class func shared() -> SingletonBase {
        struct Singleton {
            static let shared = SingletonBase()
            private init() {}
        }
        return Singleton.shared
    }
}

class SingletonClone: SingletonBase {
    override class func shared() -> SingletonClone {
        struct Singleton {
            static let shared = SingletonClone()
            private init() {}
        }
        return Singleton.shared
    }
}
