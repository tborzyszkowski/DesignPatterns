package com.mposluszny.dp.factory.simple

import com.mposluszny.dp.factory.domain.Smartphone
import com.mposluszny.dp.factory.domain.Connectivity
import com.mposluszny.dp.factory.domain.OperatingSystem

object SmartphoneFactory {
  
  def getSmartphoneWithWifiAndLinux(): Smartphone = {
    var smartphone = new Smartphone()
    smartphone.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartphone.operatingSystems = Set(OperatingSystem.LINUX) // WTF
    smartphone.screen = "cheezy wheezy rectangular smartphone display"
    smartphone
  }
  
  def getSmartphoneWithWifiBluetoothAndAndroid(): Smartphone = {
    var smartphone = new Smartphone()
    smartphone.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartphone.operatingSystems = Set(OperatingSystem.ANDROID)
    smartphone.screen = "cheezy wheezy rectangular smartphone display"
    smartphone
  }
  
  def getDefaultSmartphone(): Smartphone = {
    var smartphone = new Smartphone()
    smartphone.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartphone.operatingSystems = Set(OperatingSystem.ANDROID)
    smartphone.screen = "cheezy wheezy rectangular smartphone display"
    smartphone
  }
  
  def getSmartphoneWithNoOS(): Smartphone = {
    var smartphone = new Smartphone()
    smartphone.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartphone.operatingSystems = Set()
    smartphone.screen = "cheezy wheezy rectangular smartphone display"
    smartphone
  }
  
  def getSmartphoneWithBluetooth(): Smartphone = {
    var smartphone = new Smartphone()
    smartphone.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartphone.operatingSystems = Set()
    smartphone.screen = "cheezy wheezy rectangular smartphone display"
    smartphone
  }
}