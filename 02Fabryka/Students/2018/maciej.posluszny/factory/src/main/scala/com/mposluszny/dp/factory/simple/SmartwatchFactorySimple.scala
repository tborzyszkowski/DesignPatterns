package com.mposluszny.dp.factory.simple

import com.mposluszny.dp.factory.domain.Smartwatch
import com.mposluszny.dp.factory.domain.Connectivity
import com.mposluszny.dp.factory.domain.OperatingSystem

object TabletFactory {
  
  def getSmartwatchWithWifiAndLinux(): Smartwatch = {
    var smartwatch = new Smartwatch()
    smartwatch.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartwatch.operatingSystems = Set(OperatingSystem.LINUX) // WTF
    smartwatch.screen = "cheezy wheezy rectangular smartwatch display"
    smartwatch
  }
  
  def getSmartwatchWithWifiBluetoothAndAndroid(): Smartwatch = {
    var smartwatch = new Smartwatch()
    smartwatch.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartwatch.operatingSystems = Set(OperatingSystem.ANDROID_WEAR)
    smartwatch.screen = "cheezy wheezy rectangular smartwatch display"
    smartwatch
  }
  
  def getDefaultSmartwatch(): Smartwatch = {
    var smartwatch = new Smartwatch()
    smartwatch.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartwatch.operatingSystems = Set(OperatingSystem.ANDROID_WEAR)
    smartwatch.screen = "cheezy wheezy rectangular smartwatch display"
    smartwatch
  }
  
  def getSmartwatchWithNoOS(): Smartwatch = {
    var smartwatch = new Smartwatch()
    smartwatch.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
//    smartwatch.operatingSystems = Set(OperatingSystem.ANDROID_WEAR) // NAJS
    smartwatch.screen = "cheezy wheezy rectangular smartwatch display"
    smartwatch
  }
  
  def getSmartwatchWithBluetooth(): Smartwatch = {
    var smartwatch = new Smartwatch()
    smartwatch.connectivity = Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    smartwatch.operatingSystems = Set(OperatingSystem.ANDROID_WEAR)
    smartwatch.screen = "cheezy wheezy rectangular smartwatch display"
    smartwatch
  }
}