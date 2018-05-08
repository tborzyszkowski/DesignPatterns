package com.mposluszny.dp.prototype

import com.mposluszny.dp.prototype.domain.Manufacturer
import com.mposluszny.dp.prototype.domain.Screen
import com.mposluszny.dp.prototype.domain.Laptop
import com.mposluszny.dp.prototype.domain.Device
import com.mposluszny.dp.prototype.domain.OperatingSystem

object DevicePrototypeFactory {
  
  /**
   * We're using a Samsung laptop with preinstalled Windows as prototype for our new laptop series.
   * This laptop will be available in several variants with different connectivity systems
   */
  def laptopPrototype(): Device = {
    val manufacturer = new Manufacturer("Samsung")
    val screen = new Screen("15,6' IPS", manufacturer)
    var laptop = new Laptop("Samsung laptop", screen)
    laptop.operatingSystems = Set(OperatingSystem.WINDOWS)
    laptop
  }
}