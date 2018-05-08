package com.mposluszny.dp.factory.abstractx

import com.mposluszny.dp.factory.domain.Device
import com.mposluszny.dp.factory.domain.Smartphone
import com.mposluszny.dp.factory.domain.Connectivity
import com.mposluszny.dp.factory.domain.OperatingSystem

object SmartphoneFactory extends DeviceFactory {
  
  def getDeviceWithWifiAndLinux(): Device = {
    var smartphone = new Smartphone()
    smartphone.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartphone.operatingSystems = Set(OperatingSystem.LINUX) // WTF
    smartphone.screen = "cheezy wheezy rectangular smartphone display"
    smartphone
  }
  
  def getDeviceWithWifiBluetoothAndAndroid(): Device = {
    var smartphone = new Smartphone()
    smartphone.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartphone.operatingSystems = Set(OperatingSystem.ANDROID)
    smartphone.screen = "cheezy wheezy rectangular smartphone display"
    smartphone
  }
  
  def getDefaultDevice(): Device = {
    var smartphone = new Smartphone()
    smartphone.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartphone.operatingSystems = Set(OperatingSystem.ANDROID)
    smartphone.screen = "cheezy wheezy rectangular smartphone display"
    smartphone
  }
  
  def getDeviceWithNoOS(): Device = {
    var smartphone = new Smartphone()
    smartphone.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartphone.operatingSystems = Set()
    smartphone.screen = "cheezy wheezy rectangular smartphone display"
    smartphone
  }
  
  def getDeviceWithBluetooth(): Device = {
    var smartphone = new Smartphone()
    smartphone.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartphone.operatingSystems = Set()
    smartphone.screen = "cheezy wheezy rectangular smartphone display"
    smartphone
  }
}