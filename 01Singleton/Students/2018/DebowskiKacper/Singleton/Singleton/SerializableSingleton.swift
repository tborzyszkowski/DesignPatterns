//
//  SerializableSingleton.swift
//  Singleton
//
//  Created by Kacper Debowski on 08/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

enum SingletonError: Error {
    case PleaseUseGetInstanceInstead
}

class SerializableKindaSafeSingleton: Codable {
    private static var instance: SerializableKindaSafeSingleton? = nil
    
    var timestamp: Double = 0
    
    private init() {
        self.timestamp = NSDate().timeIntervalSince1970
    }
    
    required init(from decoder: Decoder) throws {
        throw SingletonError.PleaseUseGetInstanceInstead
    }
    
    static func getInstance() -> SerializableKindaSafeSingleton {
        if instance == nil {
            objc_sync_enter(self)
            if instance == nil {
                usleep(100000)
                instance = SerializableKindaSafeSingleton()
            }
            objc_sync_exit(self)
        }
        return instance!
    }
}
