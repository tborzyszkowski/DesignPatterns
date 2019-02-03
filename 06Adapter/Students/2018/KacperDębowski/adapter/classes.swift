//
//  PLN.swift
//  adapter
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation

class Cash {
    var billsOf10: Int = 0
    var billsOf20: Int = 0
    var billsOf50: Int = 0
    var billsOf100: Int = 0
}

class WireTransfer {
    var amount: Float = 0
    var currencyConvertion: Float = 0
}

class House {
    var area: Float = 0
    var valuePerMeter: Float = 0
}


class BankAccountAdapter {
    var value: Float = 0.0
    
    init (cash: Cash) {
        value += Float(cash.billsOf10) * 10.0
        value += Float(cash.billsOf20) * 20.0
        value += Float(cash.billsOf50) * 50.0
        value += Float(cash.billsOf100) * 100.0
    }
    
    init (transfer: WireTransfer) {
        value = transfer.amount * transfer.currencyConvertion
    }

    init (house: House) {
        value = house.area * house.valuePerMeter
    }
    
    func payForStuff(price: Float) -> Float {
        value -= price
        return value
    }
}
