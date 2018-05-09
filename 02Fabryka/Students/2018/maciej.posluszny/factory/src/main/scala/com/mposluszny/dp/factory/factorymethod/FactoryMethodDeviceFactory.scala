package com.mposluszny.dp.factory.factorymethod

import com.mposluszny.dp.factory.domain.Device
import com.mposluszny.dp.factory.domain.DeviceType
import com.mposluszny.dp.factory.domain.OperatingSystem
import com.mposluszny.dp.factory.domain.Connectivity
import com.mposluszny.dp.factory.domain.Laptop
import com.mposluszny.dp.factory.domain.Smartphone
import com.mposluszny.dp.factory.domain.Smartwatch

object FactoryMethodDeviceFactory {
  
	def getDevice(deviceType: DeviceType.Value, operatingSystems: Set[OperatingSystem.Value], connectivity: Set[Connectivity.Value]): Device = {

	  var device: Device = null
	  
	  deviceType match  {
	    case DeviceType.PC         => {
	      device = new Laptop()
	      device.screen = "laptop screen"
	    }
	    
	    case DeviceType.SMARTPHONE => {
	      device = new Smartphone()
	      device.screen = "smartphone screen"
	    }
	    
	    case DeviceType.SMARTWATCH => {
	      device = new Smartwatch()
	      device.screen = "smartwatch screen"
	    }
	  }
	  
	  device.operatingSystems = operatingSystems
	  device.connectivity     = connectivity
	  
	  device
  }
}