package com.mposluszny.dp.factory.domain

abstract class Device {
  var connectivity: Set[Connectivity.Value] = Set()
  var operatingSystems: Set[OperatingSystem.Value] = Set()
  var screen: String = ""
  var deviceType: DeviceType.Value
    
  override def toString(): String = {
    s"""[screen: $screen, connectivity: $connectivity, operatingSystems: $operatingSystems, deviceType: $deviceType]"""
  }
}