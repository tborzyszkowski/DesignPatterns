//
//  AbstractFactory.swift
//  Factory
//
//  Created by Kacper Debowski on 10/01/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

protocol AbstractMovieFactory {
    func createMovie(title: String) -> Movie?
}
