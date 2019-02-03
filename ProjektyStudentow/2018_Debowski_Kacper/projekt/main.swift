//
//  main.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

let imdb = IMDB()
var netflix = Netflix()

print(netflix.getNewMovie()!.getExtendedDescription())
