package com.mposluszny.dp.builder.domain

import com.mposluszny.dp.builder.fluent.DeviceBuilderFluent

object DeviceImplicits {
  implicit def deviceBuilder2device(value: DeviceBuilderFluent): Device = value.build()
}

abstract class Device {
  var connectivity: Set[Connectivity.Value] = Set()
  var operatingSystems: Set[OperatingSystem.Value] = Set()
  var screen: String = ""
  var deviceType: DeviceType.Value
  
  override def toString(): String = {
    s"""[screen: $screen, connectivity: $connectivity, operatingSystems: $operatingSystems, deviceType: $deviceType]"""
  }
  
  implicit def deviceBuilder2device(value: DeviceBuilderFluent): Device = value.build()
}