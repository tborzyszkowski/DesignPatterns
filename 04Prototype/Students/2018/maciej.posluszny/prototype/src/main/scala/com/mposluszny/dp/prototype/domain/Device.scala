package com.mposluszny.dp.prototype.domain

import scala.pickling.Defaults._
import scala.pickling.binary._

class Device(var deviceType: String, var name: String, var screen: Screen) extends Cloneable with Serializable {
  var connectivity: Set[String] = Set()
  var operatingSystems: Set[String] = Set()
  
  /**
   * We use clone() method and then we clear out
   */
  def shallowCopy(): Device = {
    try {
      var clone = this.clone().asInstanceOf[Device]
      clone.screen = null
      clone
    } catch {
      case e: CloneNotSupportedException => {
        println("This device is not cloneable!")
        new Object().asInstanceOf[Device]
      }
    }
  }
  
  /**
   * All properties are copied statically
   */
  def deepCopyStatic(): Device = {
	  val screen = new Screen(this.screen.name, new Manufacturer(this.screen.manufacturer.name))
    var clone = new Device(this.deviceType, this.name, screen)
    clone.connectivity = this.connectivity
    clone.name = this.name
    clone.operatingSystems = this.operatingSystems
    clone
  }
  
  def deepCopy(): Device = {
    this.pickle.unpickle[Device]
  }
  
  override def toString(): String = {
    s"""[name: $name, screen: $screen, connectivity: $connectivity, operatingSystems: $operatingSystems, deviceType: $deviceType]"""
  }
}