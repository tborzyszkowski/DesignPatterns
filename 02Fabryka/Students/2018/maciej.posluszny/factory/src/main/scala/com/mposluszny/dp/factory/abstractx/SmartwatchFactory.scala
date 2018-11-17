package com.mposluszny.dp.factory.abstractx

import com.mposluszny.dp.factory.domain.Device
import com.mposluszny.dp.factory.domain.OperatingSystem
import com.mposluszny.dp.factory.domain.Connectivity
import com.mposluszny.dp.factory.domain.Smartwatch

object SmartwatchFactory extends DeviceFactory {
  
  def getDeviceWithWifiAndLinux(): Device = {
    var smartwatch = new Smartwatch()
    smartwatch.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartwatch.operatingSystems = Set(OperatingSystem.LINUX) // WTF
    smartwatch.screen = "cheezy wheezy rectangular smartwatch display"
    smartwatch
  }
  
  def getDeviceWithWifiBluetoothAndAndroid(): Device = {
    var smartwatch = new Smartwatch()
    smartwatch.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartwatch.operatingSystems = Set(OperatingSystem.ANDROID_WEAR)
    smartwatch.screen = "cheezy wheezy rectangular smartwatch display"
    smartwatch
  }
  
  def getDefaultDevice(): Device = {
    var smartwatch = new Smartwatch()
    smartwatch.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartwatch.operatingSystems = Set(OperatingSystem.ANDROID_WEAR)
    smartwatch.screen = "cheezy wheezy rectangular smartwatch display"
    smartwatch
  }
  
  def getDeviceWithNoOS(): Device = {
    var smartwatch = new Smartwatch()
    smartwatch.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
//    smartwatch.operatingSystems = Set(OperatingSystem.ANDROID_WEAR) // NAJS
    smartwatch.screen = "cheezy wheezy rectangular smartwatch display"
    smartwatch
  }
  
  def getDeviceWithBluetooth(): Device = {
    var smartwatch = new Smartwatch()
    smartwatch.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartwatch.operatingSystems = Set(OperatingSystem.ANDROID_WEAR)
    smartwatch.screen = "cheezy wheezy rectangular smartwatch display"
    smartwatch
  }
}