//  Builders
//
//  Created by Kamil Zielinski on 17/11/16.
//
// Zadanie 1
// Wzorując się na projektach 02VehicleBuilder i 03FluentBuilder zbudować własne buildery. Buildery powinny posiadać własność FluentInterface i wykorzystywać rzutowanie konkretnego buildera na produkt (podobnie jak w projekcie 02VehicleBuilder). Język programowania dowolny.

struct Plane: CustomStringConvertible {
    var type: String
    var parts: [String] = []

    init(type: String) {
        self.type = type
    }

    var description: String { return "Plane of type \(type), with parts: \(parts)" }
}

protocol PlaneBuilder {
    func addWings() -> PlaneBuilder
    func addEngine() -> PlaneBuilder
    func setColor() -> PlaneBuilder
    func addFrame() -> PlaneBuilder
    var plane: Plane { get set }

    func build() -> Plane
}

extension PlaneBuilder {
    func build() -> Plane {
        _ = self
            .addFrame()
            .addEngine()
            .addWings()
            .setColor()

        return plane
    }
}

class F16Builder: PlaneBuilder {
    var plane: Plane

    init() {
        self.plane = Plane(type: "F16")
    }

    func addWings() -> PlaneBuilder {
        self.plane.parts.append("Triangle wings")
        return self
    }

    func addEngine() -> PlaneBuilder {
        self.plane.parts.append("Engine: General Electric F110, Pratt & Whitney F100, Silnik turbowentylatorowy")
        return self
    }

    func setColor() -> PlaneBuilder {
        self.plane.parts.append("Gray color")
        return self
    }

    func addFrame() -> PlaneBuilder {
        self.plane.parts.append("15m frame")
        return self
    }
}

class Boeing737Builder: PlaneBuilder {
    var plane: Plane

    init() {
        self.plane = Plane(type: "Boeing737B")
    }

    func addWings() -> PlaneBuilder {
        self.plane.parts.append("Long elipsed 35m long wings")
        return self
    }

    func addEngine() -> PlaneBuilder {
        self.plane.parts.append("Engine: Pratt & Whitney JT8D, CFM International CFM56")
        return self
    }

    func setColor() -> PlaneBuilder {
        self.plane.parts.append("White color")
        return self
    }

    func addFrame() -> PlaneBuilder {
        self.plane.parts.append("41,2 m frame")
        return self
    }
}

struct Garage {
    func constructUsing(planeBuilder: PlaneBuilder) -> Plane {
        return planeBuilder.build()
    }
}

print(Garage().constructUsing(planeBuilder: Boeing737Builder()).description)
print()
print(Garage().constructUsing(planeBuilder: F16Builder()).description)