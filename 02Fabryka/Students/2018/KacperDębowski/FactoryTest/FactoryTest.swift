//
//  FactoryTest.swift
//  FactoryTest
//
//  Created by Kacper Debowski on 15/12/2018.
//  Copyright © 2018 Coding Skies. All rights reserved.
//

import XCTest

class FactoryTest: XCTestCase {

    override func setUp() {
        // Put setup code here. This method is called before the invocation of each test method in the class.
    }

    override func tearDown() {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
    }
    
    func testSimpleFactory() {
        XCTAssertEqual(MovieFactory.getInstance().createMovie(genre: "Comedy")!.title, "Intouchables")
        XCTAssertEqual(MovieFactory.getInstance().createMovie(genre: "Horror")!.title, "Dracula")
        XCTAssertEqual(MovieFactory.getInstance().createMovie(genre: "Criminal")!.title, "Dirty Harry")
        XCTAssertNil(MovieFactory.getInstance().createMovie(genre: "Documentary"))
    }
    
    func testFMFactories() {
        let comedy = FMComedyMovieFactory.getInstance().createMovie(title: "Forest Gump")
        let criminal = FMCriminalMovieFactory.getInstance().createMovie(title: "Se7en")
        let horror = FMHorrorMovieFactory.getInstance().createMovie(title: "Alien")
        
        XCTAssertNotNil(comedy)
        XCTAssertNotNil(criminal)
        XCTAssertNotNil(horror)
    }
    
    func testAbstractFactory() {
        var factory: AbstractMovieFactory = ComedyMovieFactory()
        
        let comedy = factory.createMovie(title: "Kiler")
        let notComedy = factory.createMovie(title: "Dracula")

        XCTAssertNotNil(comedy)
        XCTAssertNil(notComedy)
        
        factory = HorrorMovieFactory()
        
        let horror = factory.createMovie(title: "Dracula")
        let notHorror = factory.createMovie(title: "Kiler")
        
        XCTAssertNotNil(horror)
        XCTAssertNil(notHorror)

    }

    func testPerformanceExample() {
        // This is an example of a performance test case.
        self.measure {
            // Put the code you want to measure the time of here.
        }
    }

}
