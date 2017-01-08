// Kamil Zielinkis 215521
// Wzorzec Singleton

import Foundation

// 1. Prosty singleton
class Manager {
    static let sharedInstance = Manager()
    private init() {}

    var desc: String { return "Hello from Manager" }
}

// Manager().desc // Wygeneruje blad, nie mozna stworzyc Manager bo private init
print(Manager.sharedInstance.desc)


// 2. Serializacja singletona i sposob obrony przed sklonowaniem
class Singleton: NSObject, NSCoding {
    static private var isAlreadyCreated = false
    static let sharedInstance = Singleton()
    var name: String = "TestName"

    private override init() {
        print("Singleton zostal stworzony")
//        Singleton.isAlreadyCreated = true  // bez ustawiania tej flagi mozna skopiowac singletona
    }

    // implementacja NSCoding
    func encode(with aCoder: NSCoder) {
        aCoder.encode(name, forKey: "name")
    }

    required init?(coder aDecoder: NSCoder) {
        guard let name = aDecoder.decodeObject(forKey: "name") as? String, !Singleton.isAlreadyCreated else { fatalError("Nie mozna dostac wartosci dla wlasciwosci name, lub singleton zostal juz stworzony") }
        self.name = name
        print("nowo stworzony singleton")
    }
}

// Serializacja i deserializacja
NSKeyedArchiver.archiveRootObject(Singleton.sharedInstance, toFile: "Singleton")
guard let singleton = NSKeyedUnarchiver.unarchiveObject(withFile: "Singleton") as? Singleton else { fatalError() }

// Przyklad hackowania singletona
print((singleton === Singleton.sharedInstance) ? "Tak" : "Nie")

