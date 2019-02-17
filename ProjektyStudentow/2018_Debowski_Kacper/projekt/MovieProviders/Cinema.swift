//
//  Netflix.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Cinema {
    let distributionCompany: DistributionCompany = DistributionCompany()
    
    func getNewMovie() -> CinemaMovie? {
        print("[CINEMA]: Hello, we'd like to buy a movie")
        let movie: Movie? = distributionCompany.getNewMovie(budget: Int.random(in: 10000000 ... 30000000))
        
        if movie == nil {
            return nil
        }
        
        MovieNewsManager.instance.notify(event: "new_movie_cinema", movie: movie!)
        return CinemaMovie(wrappedMovie: movie!)
    }
    
}
