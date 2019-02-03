//
//  Movies.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class MovieCatalog: MovieIterator {
    var collection: [Movie] = []
    private var currentPosition: Int = 0
    
    init () {
    }
    
    init (movies: [Movie]) {
        collection = movies
    }
    
    func getNext() -> Movie? {
        if hasMore() {
            currentPosition += 1
            return collection[currentPosition-1]
        } else {
            return nil
        }
    }
    
    func hasMore() -> Bool {
        return currentPosition < collection.count - 1
    }
    
    func reset() {
        currentPosition = 0
    }
    
    func moveBack() {
        currentPosition -= 1
    }
    
    
}
