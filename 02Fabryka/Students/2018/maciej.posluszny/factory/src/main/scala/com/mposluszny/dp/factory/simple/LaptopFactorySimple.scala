package com.mposluszny.dp.factory.simple

import com.mposluszny.dp.factory.domain.Laptop
import com.mposluszny.dp.factory.domain.Laptop
import com.mposluszny.dp.factory.domain.Laptop
import com.mposluszny.dp.factory.domain.Connectivity
import com.mposluszny.dp.factory.domain.OperatingSystem
import com.mposluszny.dp.factory.domain.DeviceType

object LaptopFactorySimple {
  
  def getLaptopWithWifiAndLinux(): Laptop = {
    var laptop = new Laptop()
    laptop.connectivity = Set(Connectivity.WIFI)
    laptop.operatingSystems = Set(OperatingSystem.LINUX)
    laptop.screen = "13-inch IPS display"
    laptop
  }
  
  def getLaptopWithWifiBluetoothAndAndroid(): Laptop = {
    var laptop = new Laptop()
    laptop.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    laptop.operatingSystems = Set(OperatingSystem.ANDROID)
    laptop.screen = "11-inch IPS display"
    laptop
  }
  
  def getDefaultLaptop(): Laptop = {
    var laptop = new Laptop()
    laptop.connectivity = Set(Connectivity.WIFI)
    laptop.operatingSystems = Set(OperatingSystem.WINDOWS)
    laptop.screen = "15.6 inch display"
    laptop
  }
  
  def getLaptopWithNoOS(): Laptop = {
    var laptop = new Laptop()
    laptop.connectivity = Set(Connectivity.WIFI)
    laptop.operatingSystems = Set()
    laptop.screen = "random display"
    laptop
  }
  
  def getLaptopWithBluetooth(): Laptop = {
    var laptop = new Laptop()
    laptop.connectivity = Set(Connectivity.BLUETOOTH)
    laptop.operatingSystems = Set(OperatingSystem.WINDOWS)
    laptop.screen = "random display"
    laptop
  }
}