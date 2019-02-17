//
//  Marketing.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class MarketingTeam {
    func getMovieDescription(_ movie: Movie) -> String {
        print ("[MARKETING] We're coming up with great description!")
        var description: String = ""
        
        if (movie.sequel) {
            description += "Your favourite heroes are back! "
        } else {
            description += "This new movie will completely redefine the " + movie.genre + " genre! "
        }
        
        if movie.star.male {
            description += "Strong and mighty "
        } else {
            description += "Beautiful and charming "
        }
        
        description += movie.star.name + " " + movie.star.lastName + " is in trouble again, you won't believe your eyes! " + movie.title + " -- you have to see this! Coming soon"
        
        return description
    }
}
