package com.mposluszny.dp.factory.factorymethod

import org.junit._
import Assert._
import com.mposluszny.dp.factory.domain.Connectivity
import com.mposluszny.dp.factory.domain.DeviceType
import com.mposluszny.dp.factory.domain.OperatingSystem
import com.mposluszny.dp.factory.domain.Laptop
import com.mposluszny.dp.factory.domain.Smartphone
import com.mposluszny.dp.factory.domain.Smartwatch

class FactoryMethodTest {
	
	@Test
	def laptopWithWifiBluetoothAndAndroidTest() = {
		// Given
		val factory = FactoryMethodDeviceFactory
				
		// When
		val device = factory.getDevice(
	    DeviceType.PC,
	    Set(OperatingSystem.ANDROID),
	    Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    )
    
    // Then
		assertTrue(device.isInstanceOf[Laptop])
		assertEquals(device.deviceType, DeviceType.PC)
		assertTrue(device.connectivity contains Connectivity.WIFI)
		assertTrue(device.connectivity contains Connectivity.BLUETOOTH)
		assertTrue(device.operatingSystems contains OperatingSystem.ANDROID)
	}
	
	@Test
	def smartphoneWithWifiBluetoothAndAndroidTest() = {
		// Given
		val factory = FactoryMethodDeviceFactory
				
		// When
		val device = factory.getDevice(
	    DeviceType.SMARTPHONE,
	    Set(OperatingSystem.ANDROID),
	    Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    )
    
    // Then
		assertTrue(device.isInstanceOf[Smartphone])
		assertEquals(device.deviceType, DeviceType.SMARTPHONE)
		assertTrue(device.connectivity contains Connectivity.WIFI)
		assertTrue(device.connectivity contains Connectivity.BLUETOOTH)
		assertTrue(device.operatingSystems contains OperatingSystem.ANDROID)
	}
  
  @Test
  def smartwatchWithWifiBluetoothAndAndroidTest() = {
    // Given
		val factory = FactoryMethodDeviceFactory
				
		// When
		val device = factory.getDevice(
	    DeviceType.SMARTWATCH,
	    Set(OperatingSystem.ANDROID_WEAR),
	    Set(Connectivity.WIFI, Connectivity.BLUETOOTH)
    )
    
    // Then
		assertTrue(device.isInstanceOf[Smartwatch])
		assertEquals(device.deviceType, DeviceType.SMARTWATCH)
		assertTrue(device.connectivity contains Connectivity.WIFI)
		assertTrue(device.connectivity contains Connectivity.BLUETOOTH)
		assertTrue(device.operatingSystems contains OperatingSystem.ANDROID_WEAR)
  }
}