package com.mposluszny.dp.builder.fluent

import com.mposluszny.dp.builder.domain.Device
import com.mposluszny.dp.builder.domain.Smartphone
import com.mposluszny.dp.builder.domain.Connectivity
import com.mposluszny.dp.builder.domain.OperatingSystem

class SmartphoneBuilder(device: Device = new Smartphone()) extends DeviceBuilderFluent {

  def connectivity(): DeviceBuilderFluent = {
    device.connectivity = device.connectivity + (Connectivity.GSM, Connectivity.BLUETOOTH, Connectivity.WIFI)
    this
  }
  
  def operatingSystem(operatingSystems: Set[OperatingSystem.Value]): DeviceBuilderFluent = {
    device.operatingSystems = device.operatingSystems ++ (operatingSystems)
    this
  }
  
  def screen(): DeviceBuilderFluent = {
    device.screen = "4.95' IPS"
    this
  }
  
  def build(): Device = {
    device
  }

}