//
//  KonkretneCiasta.swift
//  ProjetWzorce-GithubViewer
//
//  Created by Kamil Zielinski on 15/01/2017.
//  Copyright © 2017 Kamil Zielinski. All rights reserved.
//

import Foundation

class CiastoPan: Ciasto {
    required init() {}
    var name: String { return "Ciasto Pan" }
    var przepis: String! { return "Puszyste w środku, chrupiące na zewnątrz. Podawane w czarnej patelni prosto z pieca" }
}

class CiastoTradycyjne: Ciasto {
    required init() {}
    var name: String { return "Ciasto Tradycyjne" }
    var przepis: String! { return "Ręcznie formowane jak ciasto domowe. Delikatne w środku i wyrośnięte na brzegach" }
}

class CiastoTradycyjneZSerem: Ciasto {
    required init() {}
    var name: String { return "Ciasto Tradycyjne Z Serem" }
    var przepis: String! { return "Ręcznie formowane jak ciasto domowe. Delikatne w środku i wyrośnięte na brzegach wypełnionych mnóstwem pysznego sera" }
}

extension String {
    var initials: String {
        return self.components(separatedBy: " ").reduce("") {
            return $0 + (String(describing: $1.characters.first!))
        }
    }
}
