package com.mposluszny.dp.prototype.domain

class Screen(val name: String, val manufacturer: Manufacturer) {
  
  override def toString(): String = {
    s"""[name: $name, manufacturer: $manufacturer]"""
  }
}