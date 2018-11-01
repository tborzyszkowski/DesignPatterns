//
//  ThreadSafeSingleton.swift
//  Singleton
//
//  Created by Patryk Iwaniuk on 01/11/2018.
//  Copyright © 2018 Patryk Iwaniuk. All rights reserved.
//
import Foundation

class Singleton {
    private static var _shared: Singleton!
    
    class var sharedInstance: Singleton {
        if _shared == nil {
            DispatchQueue.global().async {
                if _shared == nil {
                    _shared = Singleton()
                }
            }
        }
        return _shared!
    }

    private init() {}
}
