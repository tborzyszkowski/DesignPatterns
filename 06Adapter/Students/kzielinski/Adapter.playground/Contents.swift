// Kamil Zielinkis 215521
// Wzorzec Adapter
// Moze niekoniecznie dokonca trafione przyklady ale pokazuja idea adaptera

// Przyklad adaptera objektowego
// Mamy protokol [interface]
protocol Pojazd {
    var prowadzonyPrzez:String { get }
    var maksymalnaIloscPrzewozonychOsob:Int { get }
    var desc: String {get}
    func jedz()
}

extension Pojazd {
    var desc: String { return "\(prowadzonyPrzez), moze zabrac max liczbe osob = \(maksymalnaIloscPrzewozonychOsob)\n" }
}

struct Klient: CustomStringConvertible {
    var imie:String
    var pojazdy: [Pojazd]

    var description: String {
        let pojazdyDesc = pojazdy.reduce("") {
            return "\($0.0) \($0.1.desc)"
        }
        return "\(imie) moze prowadzic nastapujce pojazdy jako \n\(pojazdyDesc)"
    }
}

// Wyobrazmy sobie ze mamy jedna klase "Kon" ktora pochodzi z innego projektu oraz dwie ktore pochodza z obecnego projektu "Rower" i "Auto"

struct Kon {
    var imieJezdzica: String
    var aktualnaMasa: Int
    func galop() {
        print("Kon sie porusza")
    }
}

struct Rower: Pojazd {
    var prowadzonyPrzez:String
    var maksymalnaIloscPrzewozonychOsob:Int
    func jedz() {

    }
}

struct Auto: Pojazd {
    var prowadzonyPrzez:String
    var maksymalnaIloscPrzewozonychOsob:Int
    func jedz() {

    }
}

//let pojazd:Pojazd = Kon(imieJezdzica: "Cowboy", aktualnaMasa: 300) // Wygeneruje blad

// W takiej sytuacji nie mozemy potraktowac Konia jako pojazdu, Aby to bylo mozliwe musimy powiedziec, ze Konia tez mozna traktowac jako pojazd [zaimlementowac Koniu protokol Pojazd]
extension Kon: Pojazd {
    var prowadzonyPrzez:String { return imieJezdzica }
    var maksymalnaIloscPrzewozonychOsob:Int { return 1 }
    func jedz() { galop() }
}

// Gdy to nastapi mozna tratkowac Konia jako pojazd

let pojazdy:[Pojazd] = [
    Rower(prowadzonyPrzez: "Rowerzysta", maksymalnaIloscPrzewozonychOsob: 1),
    Auto(prowadzonyPrzez: "Kierowca", maksymalnaIloscPrzewozonychOsob: 5),
    Kon(imieJezdzica: "Cowboy", aktualnaMasa: 300),
]

print(Klient(imie: "Kamil", pojazdy: pojazdy))


////////////////// BONUS /////////////////////
// Scenariusz: mamy juz sobie zdefiniowane pare klas ktore moga byc postrzegane jako prostokat, jednak przychodzi nowe wymaganie zeby te figury malowac w innym systemie, ktory wymaga od nas implementacji protokolu DrawableShape. 
// W Swifcie, dzieki extensionom mozemy za jednym "zamachem" powiedziec paru typom jak przetlumaczyc ich wlasciwosci na nowe wymagania. Patrz `extension DrawableShape where Self: Prostokat`
class Shape {
    var name: String
    init(name: String) {
        self.name = name
    }
}

protocol Prostokat: DrawableShape {
    var bokA: Int { get set }
    var bokB: Int { get set }
}

final class Romb: Shape, Prostokat {
    var bokA: Int
    var bokB: Int
    init(name: String, bokA: Int, bokB:Int) {
        self.bokA = bokA
        self.bokB = bokB
        super.init(name: name)
    }
}

final class Kwadrat: Shape, Prostokat {
    var bokA: Int
    var bokB: Int
    init(name: String, bokA: Int, bokB:Int) {
        self.bokA = bokA
        self.bokB = bokB
        super.init(name: name)
    }
}

protocol DrawableShape {
    var area: Int { get }
}

// Romb(name: "romb", bokA: 4, bokB: 4).area // wygeneruje blad ze nie ma takiej wlasciwosci jak area

// Dzieki temu extensionowi wszystkie typy ktore implementuja interface Prostokat wiedza jak obliczyc swoje pole (area)
// To oszdzedza nam implementacji protokolu DrawableShape dla czesci objektow wywodzadzych sie z typu Shape
extension DrawableShape where Self: Prostokat {
    var area: Int { return self.bokA * self.bokB }
}

Romb(name: "romb", bokA: 4, bokB: 4).area

class TrojkatRownoboczny: Shape {
    var bokA: Int
    init(name: String, bokA: Int) {
        self.bokA = bokA
        super.init(name: name)
    }
}

// TrojkatRownoboczny(name: "Trojkat rownoboczny", bokA: 10).area  // blad - nie ma takiej wlasciwlosc jak area
