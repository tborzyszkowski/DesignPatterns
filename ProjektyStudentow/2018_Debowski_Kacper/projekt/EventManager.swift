//
//  EventManager.swift
//  projekt
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class MovieNewsManager {
    static let instance = MovieNewsManager()
    private var listeners: [String : MoviePress] = [String : MoviePress]()
    
    func subscribe(event: String, listener: MoviePress) {
        listeners[event] = listener
    }
    
    func notify(event: String, movie: Movie) {
        self.listeners[event]?.reactToEvent(eventType: event, movie: movie)
    }
}
