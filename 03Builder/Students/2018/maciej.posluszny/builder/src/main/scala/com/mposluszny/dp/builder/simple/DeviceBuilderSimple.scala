package com.mposluszny.dp.builder.simple

import com.mposluszny.dp.builder.domain.Device
import com.mposluszny.dp.builder.domain.OperatingSystem

trait DeviceBuilderSimple {
  def screen()
  def connectivity()
  def operatingSystem(operatingSystems: Set[OperatingSystem.Value])
  def build(): Device
}