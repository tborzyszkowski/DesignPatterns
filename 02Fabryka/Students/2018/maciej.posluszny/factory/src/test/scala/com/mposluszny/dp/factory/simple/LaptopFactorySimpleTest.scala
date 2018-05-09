package com.mposluszny.dp.factory.simple

import org.junit._
import com.mposluszny.dp.factory.domain.Connectivity
import com.mposluszny.dp.factory.domain.DeviceType
import Assert._
import com.mposluszny.dp.factory.domain.OperatingSystem

class LaptopFactorySimpleTest {
  
  @Test
  def laptopWithWifiAndLinuxTest() = {
    // Given
    
    // When
	  val device = LaptopFactorySimple.getLaptopWithWifiAndLinux()
    
    // Then
		assertTrue(device.deviceType == DeviceType.PC)
		assertTrue(device.operatingSystems contains OperatingSystem.LINUX)
		assertTrue(device.connectivity contains Connectivity.WIFI)
  }
  
  @Test
  def macbookTest() = {
    // Given
    
    // When
	  val device = LaptopFactorySimple.getLaptopWithNoOS()
    
    // Then
		assertTrue(device.deviceType == DeviceType.PC)
		assertTrue(device.operatingSystems isEmpty)
  }
}