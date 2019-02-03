//
//  BuilderTest.swift
//  BuilderTest
//
//  Created by Kacper Debowski on 10/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import XCTest

class BuilderTest: XCTestCase {

    override func setUp() {
        // Put setup code here. This method is called before the invocation of each test method in the class.
    }

    override func tearDown() {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
    }

    func testFluentBuilder() {
        let comedy: Movie = Movie(ComedyMovieBuilder())
        let criminal: Movie = Movie(CriminalMovieBuilder())
        
        XCTAssertEqual(comedy.title, "Forest Gump")
        XCTAssertEqual(comedy.star, "Tom Hanks")
        
        XCTAssertEqual(criminal.title, "Dirty Harry")
        XCTAssertEqual(criminal.star, "Clint Eastwood")
    }

    func testPerformanceExample() {
        // This is an example of a performance test case.
        self.measure {
            // Put the code you want to measure the time of here.
        }
    }

}
