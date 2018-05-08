package com.mposluszny.dp.builder.simple

import com.mposluszny.dp.builder.domain.Device
import com.mposluszny.dp.builder.domain.Laptop
import com.mposluszny.dp.builder.domain.Connectivity
import com.mposluszny.dp.builder.domain.OperatingSystem

class SmartwatchBuilder(device: Device = new Laptop()) extends DeviceBuilderSimple {
  
  def connectivity(): Unit = {
    device.connectivity = device.connectivity + (Connectivity.BLUETOOTH, Connectivity.WIFI)
  }
  
  def operatingSystem(operatingSystems: Set[OperatingSystem.Value]): Unit = {
    device.operatingSystems = device.operatingSystems ++ (operatingSystems)
  }
  
  def screen(): Unit = {
    device.screen = "1.8' AMOLED"
  }
  
  def build(): Device = {
    device
  }
}