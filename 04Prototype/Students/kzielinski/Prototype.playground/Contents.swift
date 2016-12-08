//: Prototype

/*
    Author: Kamil Zielinski
    Desc: 
        W Swifcie niestety nie ma mechanizmu umozliwiajacego kopiowania. 
        Wszystko trzeba napisac "recznie"
 */

import Foundation

// Helpers

func address<T: AnyObject>(_ o: T) -> Int {
    return unsafeBitCast(o, to: Int.self)
}

func address(_ o: UnsafeRawPointer) -> Int {
    return unsafeBitCast(o, to: Int.self)
}

// End

// Protokol ktory wymusza na typie ktory go implementuje mozliwosc kopiowania.
protocol Copyable {
    /// Zwraca Self (czyli typ ktory go implementuje)
    func copy() -> Self
}

// Mamy 3 klasy: ObjectA, ObjectB oraz ObjectC. Klasy ObjectA i ObjectB maja odwolanie do innych objektow. Dodatkowo kazdy z ObjectX maja po jeden wlasciwiosci  o typie referencyjnym oraz typie wartosciowym
final class ObjectC: Copyable {
    var value: Int
    var ref: String

    init(value:Int, refValue: String) {
        self.value = value
        self.ref = refValue
    }

    // Niestety to w kwestii developera pozostaje obowiazek napisania mechanizmu kopiowania
    func copy() -> ObjectC {
        return ObjectC(value: value, refValue: ref)
    }
}

final class ObjectB: Copyable {
    var myValue: Int
    var myRefValue: String
    var objectC: ObjectC

    init(value:Int, refValue: String, objectC: ObjectC) {
        self.myValue = value
        self.myRefValue = refValue
        self.objectC = objectC
    }

    func copy() -> ObjectB {
        return ObjectB(
            value: myValue,
            refValue: myRefValue,
            objectC: objectC.copy()) // .copy() tworzy w tym przypadku 'Deep Copy'
    }
}

final class ObjektA: Copyable {
    var someValueType: Int
    var someRefType: String
    var objectB: ObjectB

    init(valueType: Int, refType: String, objectB: ObjectB) {
        self.someValueType = valueType
        self.someRefType = refType
        self.objectB = objectB
    }

    func copy() -> ObjektA {
        return ObjektA(
            valueType: someValueType,
            refType: someRefType,
            objectB: objectB.copy()
        )
    }
}

// Tworzymy 3 objekty i 'podlaczamy' je ze soba
var objectC = ObjectC(value: 3, refValue: "ThirdClass")
address(objectC)
address(objectC.ref)
address(&objectC.value)

var objectB = ObjectB(value: 2, refValue: "MyClass", objectC: objectC)
address(objectB)
address(objectB.myRefValue)
address(&objectB.myValue)

var objectA = ObjektA(valueType: 1, refType: "Test", objectB: objectB)
address(objectA)
address(objectA.objectB)
address(objectA.someRefType)
address(&objectA.someValueType)


// Przyklad przypisania objektu (adresy sa takie same)
var objectAByAssign = objectA
address(objectAByAssign)
address(objectAByAssign.objectB)
address(objectAByAssign.someRefType)
address(&objectAByAssign.someValueType)
print((objectA === objectAByAssign) ? "Tak" : "Nie" )

// Przyklad kopii (adressy sa inne)
var copyOfObjA = objectA.copy()
address(copyOfObjA)
address(copyOfObjA.objectB)
address(copyOfObjA.someRefType)
address(&copyOfObjA.someValueType)
print((objectA === copyOfObjA) ? "Tak" : "Nie" )





