package com.mposluszny.dp.prototype.domain

class Manufacturer(val name: String) {
  
  override def toString(): String = {
    s"""[name: $name]"""
  }
}