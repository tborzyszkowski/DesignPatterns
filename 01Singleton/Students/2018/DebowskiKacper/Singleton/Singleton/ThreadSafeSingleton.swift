//
//  ThreadSafeSingleton.swift
//  Singleton
//
//  Created by Kacper Debowski on 07/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import Foundation

class ThreadSafeSingleton: Codable {
    private static var instance: ThreadSafeSingleton? = nil
    
    var timestamp: Double = 0

    private init() {
        self.timestamp = NSDate().timeIntervalSince1970
    }
    
    static func getInstance() -> ThreadSafeSingleton {
        if instance == nil {
            objc_sync_enter(self)
            if instance == nil {
                usleep(100000)
                instance = ThreadSafeSingleton()
            }
            objc_sync_exit(self)
        }
        return instance!
    }
}



