//
//  PrototypeTest.swift
//  PrototypeTest
//
//  Created by Kacper Debowski on 12/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import XCTest

class PrototypeTest: XCTestCase {

    override func setUp() {
        // Put setup code here. This method is called before the invocation of each test method in the class.
    }

    override func tearDown() {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
    }

    func testSimplePrototype() {
        let movie: Movie = Movie("Dirty Harry", "Clint Eastwood", 1971)
        let copy = movie.clone() as! Movie
        
        XCTAssertEqual(movie.describe(), copy.describe())
        XCTAssertNotEqual(ObjectIdentifier(movie), ObjectIdentifier(copy))
    }
    
    func testDeepCopyPrototype() {
        let menu = Menu()
        
        menu.addMeal(meal:
            Meal(["zupa pomidorowa", "schabowy", "ziemniaczki"])
        )
        
        let restaurant = Restaurant("Pyszna 13, Gdańsk", menu)
        let deepCopyRestaurant: Restaurant = restaurant.deepCopy()

        XCTAssertEqual(restaurant, deepCopyRestaurant)
        
        XCTAssertNotEqual(ObjectIdentifier(restaurant), ObjectIdentifier(deepCopyRestaurant))
        XCTAssertNotEqual(ObjectIdentifier(restaurant.menu), ObjectIdentifier(deepCopyRestaurant.menu))
    }

    func testPerformanceExample() {
        // This is an example of a performance test case.
        self.measure {
            // Put the code you want to measure the time of here.
        }
    }

}
