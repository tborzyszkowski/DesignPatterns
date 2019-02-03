//
//  Distribution.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class DistributionCompany {
    let salesCompany: SalesCompany = SalesCompany()
    let productionCompany: MovieProductionCompany = MovieProductionCompany()
    let marketingTeam: MarketingTeam = MarketingTeam()
    let movieNewsManager: MovieNewsManager = MovieNewsManager.instance

    func getNewMovie(budget: Int) -> Movie? {
        var movie: Movie?
        movie = productionCompany.catalog.getNext()!
        
        if movie == nil {
            print("[DISTRIBUTION]: There are no new movies, sorry")
            return nil
        }
        
        movie = salesCompany.estimatePrice(ofMovie: movie!)
        
        if budget < movie!.price {
            print("[DISTRIBUTION]: You can't afford " + movie!.title + ", sorry")
            productionCompany.catalog.moveBack()
            return nil
        }
        print ("[DISTRIBUTION] Here's your movie!")
        movie!.description = marketingTeam.getMovieDescription(movie!)
        movieNewsManager.notify(event: "new_movie", movie: movie!)
        
        return movie
    }
}
