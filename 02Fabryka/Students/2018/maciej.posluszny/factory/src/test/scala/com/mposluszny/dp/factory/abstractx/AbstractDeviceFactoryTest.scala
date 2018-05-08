package com.mposluszny.dp.factory.abstractx

import org.junit._
import Assert._
import com.mposluszny.dp.factory.domain.Connectivity
import com.mposluszny.dp.factory.domain.DeviceType
import com.mposluszny.dp.factory.domain.OperatingSystem
import com.mposluszny.dp.factory.domain.Laptop
import com.mposluszny.dp.factory.domain.Smartphone
import com.mposluszny.dp.factory.domain.Smartwatch

class AbstractDeviceFactoryTest {
	
	@Test
	def laptopFactoryTest = {
			// Given
			val factory: DeviceFactory = LaptopFactory
					
			// When
			val device = factory.getDeviceWithWifiBluetoothAndAndroid()
			
			// Then
			assertTrue(device.isInstanceOf[Laptop])
			assertEquals(device.deviceType, DeviceType.PC)
			assertTrue(device.connectivity contains Connectivity.WIFI)
			assertTrue(device.connectivity contains Connectivity.BLUETOOTH)
			assertTrue(device.operatingSystems contains OperatingSystem.ANDROID)
	}
	
	@Test
	def smartphoneFactoryTest = {
			// Given
			val factory: DeviceFactory = SmartphoneFactory
					
			// When
			val device = factory.getDeviceWithWifiBluetoothAndAndroid()
			
			// Then
			assertTrue(device.isInstanceOf[Smartphone])
			assertEquals(device.deviceType, DeviceType.SMARTPHONE)
			assertTrue(device.connectivity contains Connectivity.WIFI)
			assertTrue(device.connectivity contains Connectivity.BLUETOOTH)
			assertTrue(device.operatingSystems contains OperatingSystem.ANDROID)
	}
  
  @Test
  def smartwatchFactoryTest = {
    // Given
			val factory: DeviceFactory = SmartwatchFactory
					
			// When
			val device = factory.getDeviceWithWifiBluetoothAndAndroid()
			
			// Then
			assertTrue(device.isInstanceOf[Smartwatch])
			assertEquals(device.deviceType, DeviceType.SMARTWATCH)
			assertTrue(device.connectivity contains Connectivity.WIFI)
			assertTrue(device.connectivity contains Connectivity.BLUETOOTH)
			assertTrue(device.operatingSystems contains OperatingSystem.ANDROID_WEAR)
  }
}