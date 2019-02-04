//
//  main.swift
//  adapter
//
//  Created by Kacper Debowski on 02/02/2019.
//  Copyright © 2019 Coding Skies. All rights reserved.
//

import Foundation


//--------------------
var house = House()

house.area = 45.5
house.valuePerMeter = 7000

let account1 = BankAccountAdapter(house: house)
print ("Po sprzedaży mieszkania mam " + String(account1.value) + " zł")
print ("Po kupieniu auta zostało: " + String(account1.payForStuff(price: 151000)) + " zł")

//--------------------
var transfer = WireTransfer()

transfer.amount = 50
transfer.currencyConvertion = 3.74

let account2 = BankAccountAdapter(transfer: transfer)
print ("Od cioci z ameryki dostałem " + String(account2.value) + " zł")
print ("Po kupieniu pizzy zostało: " + String(account2.payForStuff(price: 32.75)) + " zł")

//--------------------
var cash = Cash()

cash.billsOf10 = 4
cash.billsOf50 = 2

let account3 = BankAccountAdapter(cash: cash)
print ("Do końca miesiąca mam jeszcze " + String(account3.value) + " zł")
print ("Po zakupach zostało: " + String(account3.payForStuff(price: 51.5)) + " zł")

