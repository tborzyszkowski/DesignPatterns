//
//  Sales.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class SalesCompany {
    func estimatePrice(ofMovie: Movie) -> Movie {
        print ("[SALES] Our team is calculating the value of this movie...")
        ofMovie.price = Int.random(in: 1000000 ... 60000000)
        return ofMovie
    }
}
