//
//  SingletonWithIngeritanceTest.swift
//  SingletonTests
//
//  Created by Patryk Iwaniuk on 01/11/2018.
//  Copyright © 2018 Patryk Iwaniuk. All rights reserved.
//

import XCTest

class SingletonWithIngeritanceTest: XCTestCase {
    func testDifference() {
        let firstSingleton = SingletonBase.shared()
        let secondSingleton = SingletonClone.shared()
        
        XCTAssertFalse(firstSingleton === secondSingleton)
        XCTAssertTrue(type(of: secondSingleton) == SingletonClone.self)
        XCTAssertTrue(secondSingleton.isKind(of: SingletonBase.self))
    }
}
