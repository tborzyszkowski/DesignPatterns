//
//  main.swift
//  Singleton
//
//  Created by Kacper Debowski on 07/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class NaiveSingleton {
    private static var instance: NaiveSingleton? = nil
    
    var timestamp: Double = 0
    
    private init() {
        timestamp = NSDate().timeIntervalSince1970
    }
    
    static func getInstance() -> NaiveSingleton {
        if instance == nil {
            // 100 000 μs = 100 ms
            usleep(100000)
            instance = NaiveSingleton()
        }
        return instance!
    }
}


