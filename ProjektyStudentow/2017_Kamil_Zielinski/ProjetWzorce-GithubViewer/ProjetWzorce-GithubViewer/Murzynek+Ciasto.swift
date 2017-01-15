//
//  Murzynek+Ciasto.swift
//  ProjetWzorce-GithubViewer
//
//  Created by Kamil Zielinski on 15/01/2017.
//  Copyright © 2017 Kamil Zielinski. All rights reserved.
//

import Foundation

// ==== <Adapter>
class CiastoMurzynek {
    var recepta: String! { return " W rondelku zagotować margarynę z cukrem i kakao, nastpnie dodać wodę. Z tak wytworzonej polewy czkoladowej odlać pół szklanki. Polewę ostudzić. Mąkę przesiać razem z proszkiem do pieczenia, dodać do polewy wraz z jajkami, dokładnie wymieszać. Murzynek piecze się 50 minut w temp. 180 C. Po upieczeniu polać pozostawioną polewą czekoladową."
    }

    required init() {}
}

extension CiastoMurzynek: Ciasto {
    var name: String { return "Murzynek" }
    var przepis:String! { return recepta }
}
// ==== <Adapter>
