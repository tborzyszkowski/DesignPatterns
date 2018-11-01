//
//  ThreadSafeSingletonTest.swift
//  SingletonTests
//
//  Created by Patryk Iwaniuk on 01/11/2018.
//  Copyright © 2018 Patryk Iwaniuk. All rights reserved.
//

import XCTest

class ThreadSafeSingletonTest: XCTestCase {

    func testInit() {
        let singleton = Singleton.sharedInstance
        XCTAssertNotNil(singleton)
    }
    
    func testTwoEqualInstances() {
        let firstSingleton = Singleton.sharedInstance
        let secondSingleton = Singleton.sharedInstance
        XCTAssertTrue(firstSingleton === secondSingleton)
    }
    
    func testThreadSafety() {
        var firstSingleton: Singleton!
        var secondSingleton: Singleton!
        
        let exp1 = expectation(description: "firstSingleton initialized")
        let exp2 = expectation(description: "secondSingleton initialized")
        
        DispatchQueue.global(qos: .background).async {
            firstSingleton = Singleton.sharedInstance
            exp1.fulfill()
        }
        
        DispatchQueue.global(qos: .background).async {
            secondSingleton = Singleton.sharedInstance
            exp2.fulfill()
        }
        
        waitForExpectations(timeout: 5.0, handler: { _ in
            XCTAssertTrue(firstSingleton === secondSingleton)
        })
    }

}
