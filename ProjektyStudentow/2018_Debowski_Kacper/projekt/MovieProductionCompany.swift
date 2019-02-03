//
//  MovieProductionCompany.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class MovieProductionCompany {
    let castingAgency: CastingAgency = StarCastAgency()
    var catalog: MovieCatalog = MovieCatalog()
    
    init () {
        var films: [Movie] = []
        films.append(produceABlockbusterMovie(title: "Smoking Guns", genre: "action"))
        films.append(produceASequel(originalMovie: films[0], part: 2, subtitle: "Back In Action"))
        films.append(produceASequel(originalMovie: films[0], part: 3, subtitle: "One More Time"))
        
        films.append(produceABlockbusterMovie(title: "Love In The Air", genre: "romance"))
        films.append(produceABlockbusterMovie(title: "Blood On The Streets", genre: "historical"))
        films.append(produceABlockbusterMovie(title: "Merry Christmas", genre: "horror"))
        
        catalog = MovieCatalog(movies: films)
    }

    func produceABlockbusterMovie(title: String, genre: String) -> Movie {
        let star: Actor = self.castingAgency.castActor()
        return Movie(title, star, genre)
    }
    
    func produceASequel(originalMovie: Movie, part: Int, subtitle: String) -> Movie {
        let sequel: Movie = originalMovie.clone() as! Movie
        sequel.sequel = true
        sequel.title += " " + String(part) + ": " + subtitle
        return sequel
    }
}
