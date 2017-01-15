//
//  Ciasto.swift
//  ProjetWzorce-GithubViewer
//
//  Created by Kamil Zielinski on 15/01/2017.
//  Copyright © 2017 Kamil Zielinski. All rights reserved.
//

import Foundation

protocol Ciasto {
    // opis jak zrobic ciasto
    var name:String { get }
    var przepis: String! { get }
    func prepare()
    init()
}

extension Ciasto {
    var name: String {
        return String(describing: self.self)
    }

    func prepare() { print("/n Uwaga robie ciasto: /n \(przepis)") }
}

class CiastoFactory {
    func ciasto(typu:  Ciasto.Type) -> Ciasto {
        let ciasto = typu.init()
        ciasto.prepare()
        return ciasto
    }
}
