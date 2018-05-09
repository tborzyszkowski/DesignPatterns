package com.mposluszny.dp.builder.simple

import com.mposluszny.dp.builder.domain.Device
import com.mposluszny.dp.builder.domain.Smartphone
import com.mposluszny.dp.builder.domain.Connectivity
import com.mposluszny.dp.builder.domain.OperatingSystem

class SmartphoneBuilder(device: Device = new Smartphone()) extends DeviceBuilderSimple {
 
  def connectivity(): Unit = {
    device.connectivity = device.connectivity + (Connectivity.BLUETOOTH, Connectivity.WIFI)
  }
  
  def operatingSystem(operatingSystems: Set[OperatingSystem.Value]): Unit = {
    device.operatingSystems = device.operatingSystems ++ (operatingSystems)
  }
  
  def screen(): Unit = {
    device.screen = "13' built-in display"
  }
  
  def build(): Device = {
    device
  }
}