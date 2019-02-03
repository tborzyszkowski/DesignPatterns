//
//  Filmweb.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class IMDB: MoviePress {
    init() {
        MovieNewsManager.instance.subscribe(event: "new_movie", listener: self)
    }
    
    func reactToEvent(eventType: String, movie: Movie) {
        if eventType == "new_movie" {
            print ("[IMDB]: New movie alert: " + movie.title)
        }
        
        if eventType == "new_on_nextflix" {
            print ("[IMDB]: " + movie.title + " starring " + movie.star.name + " " + movie.star.lastName + " just landed on Netflix!")
        }
        
        if eventType == "new_on_nextflix" {
            print ("[IMDB]: " + movie.title + " starring " + movie.star.name + " " + movie.star.lastName + " just hit the cinema!")
        }
        
    }
}
