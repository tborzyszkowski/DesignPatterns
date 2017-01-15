//
//  RechabilityObservator.swift
//  ProjetWzorce-GithubViewer
//
//  Created by Kamil Zielinski on 15/01/2017.
//  Copyright © 2017 Kamil Zielinski. All rights reserved.
//

import Alamofire

protocol InternetRechabilityObservator {
    func internetRachabilityChanged(to status: RechabilityObservator.Status)
}

class RechabilityObservator {
    enum Status {
        case reachable, notReachable
    }

    static let shearedInstance = RechabilityObservator()

    private let reachabilityManager = Alamofire.NetworkReachabilityManager(host: "www.apple.com")
    private var observators:[InternetRechabilityObservator] = []

    init () {
        self.reachabilityManager?.listener = { status in
            print("Network Status Changed: \(status)")
            var statusToNotify:RechabilityObservator.Status = .reachable
            switch status {
            case .notReachable, .unknown:
                statusToNotify = .notReachable
            case .reachable:
                statusToNotify = .reachable
            }

            self.notifyAbout(status: statusToNotify)
        }

        self.reachabilityManager?.startListening()
    }

    func add(observator: InternetRechabilityObservator) {
        observators.append(observator)
    }

    func notifyAbout(status: Status) {
        observators.forEach { $0.internetRachabilityChanged(to: status) }
    }
}
