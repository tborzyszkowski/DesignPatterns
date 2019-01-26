//
//  SingletonTest.swift
//  SingletonTest
//
//  Created by Kacper Debowski on 07/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import XCTest
@testable import Singleton

class SingletonTest: XCTestCase {

    override func setUp() {
        // Put setup code here. This method is called before the invocation of each test method in the class.
    }

    override func tearDown() {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
    }

    func testSingletonWorksAsExpected() {
        let timestamp = NaiveSingleton.getInstance().timestamp
        sleep(1)
        let timestamp2 = NaiveSingleton.getInstance().timestamp
        XCTAssert(NaiveSingleton.getInstance().timestamp == timestamp && timestamp == timestamp2)
    }
    
    func testNaiveSingletonIsNotThreadSafe() {
        var timestamps: [Double] = []
        
        class SimpleThread: Thread {
            public var timestamp: Double = 0
            
            override func main() {
                timestamp = NaiveSingleton.getInstance().timestamp
            }
        }
        
        var threads: [SimpleThread] = []
        
        for _ in 0...9 {
            let t = SimpleThread()
            t.start()
            threads.append(t)
        }

        while (true) {
            if threads.reduce(true, {res, thread in res && thread.isFinished}) {
                for i in 0...9 {
                    print (threads[i].timestamp)
                    timestamps.append(threads[i].timestamp)
                }
                break
            }
        }
        
        XCTAssertFalse(timestamps.reduce(true, {res, timestamp in res && timestamp == timestamps[0]}))

    }
    
    func testThreadSafeSingletonIsThreadSafe() {
        var timestamps: [Double] = []
        
        class SimpleThread: Thread {
            public var timestamp: Double = 0
            
            override func main() {
                timestamp = ThreadSafeSingleton.getInstance().timestamp
            }
        }
        
        var threads: [SimpleThread] = []
        
        for _ in 0...9 {
            let t = SimpleThread()
            t.start()
            threads.append(t)
        }
        
        while (true) {
            if threads.reduce(true, {res, thread in res && thread.isFinished}) {
                for i in 0...9 {
                    print (threads[i].timestamp)
                    timestamps.append(threads[i].timestamp)
                }
                break
            }
        }
        
        XCTAssertTrue(timestamps.reduce(true, {res, timestamp in res && timestamp == timestamps[0]}))
        
    }
    
    func testSimpleSerializationSucks() {
        let enc = JSONEncoder()
        enc.outputFormatting = .prettyPrinted
        let json = try! enc.encode(ThreadSafeSingleton.getInstance())
        print ("----")
        print (String(data: json, encoding: .utf8)!)
        print ("----")
        
        let dec = JSONDecoder()
        let secondSingleton = try! dec.decode(ThreadSafeSingleton.self, from: json)
        
        secondSingleton.timestamp = 0.123
        
        print(secondSingleton.timestamp)
        print(ThreadSafeSingleton.getInstance().timestamp)
        print ("----")
        
        XCTAssertFalse(secondSingleton.timestamp == ThreadSafeSingleton.getInstance().timestamp)
    }
    
    func testSerializationSafetyKindaWorks() {
        let enc = JSONEncoder()
        enc.outputFormatting = .prettyPrinted
        let json = try! enc.encode(SerializableKindaSafeSingleton.getInstance())
        print ("----")
        print (String(data: json, encoding: .utf8)!)
        print ("----")
        
        let dec = JSONDecoder()
        XCTAssertThrowsError(try dec.decode(SerializableKindaSafeSingleton.self, from: json))
    }
}
