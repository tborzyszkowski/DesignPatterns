package com.mposluszny.dp.factory.abstractx

import com.mposluszny.dp.factory.domain.Device
import com.mposluszny.dp.factory.domain.Laptop
import com.mposluszny.dp.factory.domain.Connectivity
import com.mposluszny.dp.factory.domain.OperatingSystem

object LaptopFactory extends DeviceFactory {
  
  def getDeviceWithWifiAndLinux(): Device = {
    var laptop = new Laptop()
    laptop.connectivity = Set(Connectivity.WIFI)
    laptop.operatingSystems = Set(OperatingSystem.LINUX)
    laptop.screen = "13-inch IPS display"
    laptop
  }
  
  def getDeviceWithWifiBluetoothAndAndroid(): Device = {
    var laptop = new Laptop()
    laptop.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    laptop.operatingSystems = Set(OperatingSystem.ANDROID)
    laptop.screen = "11-inch IPS display"
    laptop
  }
  
  def getDefaultDevice(): Device = {
    var laptop = new Laptop()
    laptop.connectivity = Set(Connectivity.WIFI)
    laptop.operatingSystems = Set(OperatingSystem.WINDOWS)
    laptop.screen = "15.6 inch display"
    laptop
  }
  
  def getDeviceWithNoOS(): Device = {
    var laptop = new Laptop()
    laptop.connectivity = Set(Connectivity.WIFI)
    laptop.operatingSystems = Set()
    laptop.screen = "random display"
    laptop
  }
  
  def getDeviceWithBluetooth(): Device = {
    var laptop = new Laptop()
    laptop.connectivity = Set(Connectivity.BLUETOOTH)
    laptop.operatingSystems = Set(OperatingSystem.WINDOWS)
    laptop.screen = "random display"
    laptop
  }
}