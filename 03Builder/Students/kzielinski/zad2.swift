//  Builders
//
//  Created by Kamil Zielinski on 17/11/16.
//
// Zadanie 2
// Zbudować przykład problemu wytwarzania obiektów w aplikacji, dla którego lepszym rozwiązaniem (wydajnościowo, komplikacja kodu, ...) będzie:
// a) wzorzec budowniczy (raczej niż fabryka abstrakcyjna)
// b) odwrotnie (fabryka abstrakcyjna raczej niż budowniczy)

// Ad a)
// Goal: create code to give posibilit to easly create various of different type of objects -> Builder wins
// eg:

// Goal: create code to give posibilites to easly create various objects of [the same] type -> Builder wins
// eg:

class Pizza: CustomStringConvertible {
    var name: String!
    var ingredients: [String] = []
    required init () {}

    var description: String { return "Pizza Name: \(name!), ingredients: \(ingredients)" }
}

class PizzaBuilder {
    private var pizza: Pizza

    init(pizzaName:String) {
        pizza = Pizza()
        pizza.name = pizzaName
    }

    func addTopping(_ toppingName: String) -> PizzaBuilder {
        pizza.ingredients.append(toppingName)
        return self
    }

    @discardableResult
    func build() -> Pizza {
        return pizza
    }
}

// Pizza can be even "deserialized" from JSON = unlimited possibilities
let pizzaCreatedUsingBuilder = PizzaBuilder(pizzaName: "Margaritta")
    .addTopping("Cheese")
    .addTopping("Cheese")
    .addTopping("Cham")
    .build()

class Margaritta: Pizza { // in Abstract factory new type in needed!
    required init() {
        super.init()
        name = "Margaritta"
        ingredients = ["Cheese", "Cheese", "Cham"]
    }
}

class PizzaFactory {
    func createPizzaOfType(_ pizzaType: Pizza.Type) -> Pizza {
        return pizzaType.init()
    }
}

print(pizzaCreatedUsingBuilder)
print(PizzaFactory().createPizzaOfType(Margaritta.self))


// On the other hand, if we only needs objects of specific types, it is better to use Factory Pattern over Builder

// [Another scenario could be when construcing more complext object can be encapsulated in abstract factrory -> each object know how to constuct itself]

protocol House: CustomStringConvertible {
    var numberOfBeds: Int { get set }
    var area: Double { get set }
    var levels: Int { get set }

    init()
}

extension House {
    var description: String { return "Type :\(type(of: self)), NumbOfBeds: \(numberOfBeds), Area: \(area), Levels: \(levels)" }
}

// Builder in this case would be too "open"
// Each class know how to set itself
class BlockOfFlats: House {
    var numberOfBeds: Int = 4
    var area: Double = 100.0
    var levels: Int = 4

    required init() {}
}

class Chalet: House {
    var numberOfBeds: Int = 1
    var area: Double = 30.0
    var levels: Int = 1

    required init() {}
}

class Skyscraper: House {
    var numberOfBeds: Int = 0
    var area: Double = 1000.0
    var levels: Int = 100

    required init() {}
}

class HouseFactory {
    func createHouseOfType(houseType: House.Type) -> House {
        return houseType.init()
    }
}

// No more types of building are needed 
print(HouseFactory().createHouseOfType(houseType: BlockOfFlats.self))
print(HouseFactory().createHouseOfType(houseType: Chalet.self))
print(HouseFactory().createHouseOfType(houseType: Skyscraper.self))