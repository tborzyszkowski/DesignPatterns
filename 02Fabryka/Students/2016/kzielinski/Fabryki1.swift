//  Created by Kamil Zielinski on 23/10/16.
//  Copyright © 2016 Kamil Zielinski. All rights reserved.

import Foundation

// 0. Wymysl waasna fabryke ze specyficznymi produktami i skladnikami tych produktow
// 1. "prosta fabryke" (patrz pakiet pizzas)

/**
 Implementacje simple (plus) factory pattern

 W Swifcie mozemy poprzez protokol [interface] A [Zupa] ktory wymusi na klasie implementacje konkretnego konstruktora.

 To daje nam mozliwosc napisania jednej metody generycznej ktora akteptuje Typ T taki ze T adoptuje protokol A [Zupa] przez co mamy mozliwosc stworzyc
 wyprodukowac objekt dowolnego typu ktory go implementuje.
 */

protocol Zupa { init() }

class Marchwiowa: Zupa {
    required init() {}
}

class Ogorkowa: Zupa {
    required init() {}
}

class Rosol:Zupa{
    required init() {}
}
class Pomidorowa:Rosol {
    required init() {}
}
class FabrykaZup {
    func zupa<T:Zupa>(_: T.Type) -> Zupa {
        return T()
    }
}

print(FabrykaZup().zupa(Marchwiowa.self))
print(FabrykaZup().zupa(Ogorkowa.self))
print(FabrykaZup().zupa(Pomidorowa.self))

/// Abstract version

protocol AbstractSoupFactory {
    func zupa<T:Zupa>(_: T.Type) -> T
}

class OtherFactory: AbstractSoupFactory {
    func zupa<T:Zupa>(_: T.Type) -> T {
        print("Other factory is making soup")
        // w tej fabryce mozemy np ustawic cos na tworzonym objekcie
        return T()
    }
}

print(OtherFactory().zupa(Marchwiowa.self))
print(OtherFactory().zupa(Ogorkowa.self))
