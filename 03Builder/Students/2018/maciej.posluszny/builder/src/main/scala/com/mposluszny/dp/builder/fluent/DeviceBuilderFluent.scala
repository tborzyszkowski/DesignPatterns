package com.mposluszny.dp.builder.fluent

import com.mposluszny.dp.builder.domain.Device
import com.mposluszny.dp.builder.domain.OperatingSystem

trait DeviceBuilderFluent {
  def screen(): DeviceBuilderFluent
  def connectivity(): DeviceBuilderFluent
  def operatingSystem(operatingSystems: Set[OperatingSystem.Value]): DeviceBuilderFluent
  def build(): Device
}