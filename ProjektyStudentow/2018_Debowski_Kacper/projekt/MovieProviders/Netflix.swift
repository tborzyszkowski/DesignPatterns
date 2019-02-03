//
//  Netflix.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Netflix {
    let distributionCompany: DistributionCompany = DistributionCompany()
    
    func getNewMovie() -> NetflixMovie? {
        print("[NETFLIX]: Hello, we'd like to buy a movie")
        let movie: Movie? = distributionCompany.getNewMovie(budget: Int.random(in: 50000000 ... 80000000))
        
        if movie == nil {
            return nil
        }
        
        MovieNewsManager.instance.notify(event: "new_movie_netflix", movie: movie!)
        return NetflixMovie(wrappedMovie: movie!)
    }
    
}
