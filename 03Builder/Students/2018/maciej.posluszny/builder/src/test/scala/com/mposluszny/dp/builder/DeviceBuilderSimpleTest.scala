package com.mposluszny.dp.builder

import com.mposluszny.dp.builder.simple.SmartphoneBuilder
import com.mposluszny.dp.builder.simple.LaptopBuilder
import com.mposluszny.dp.builder.simple.SmartwatchBuilder
import com.mposluszny.dp.builder.simple.DeviceBuilderSimple
import com.mposluszny.dp.builder.domain.Device
import com.mposluszny.dp.builder.domain.OperatingSystem
import org.junit._
import Assert._

class DeviceBuilderSimpleTest {
	
	@Test
	def buildSmartphoneTest() = {
			// Given
			val builder: DeviceBuilderSimple = new SmartphoneBuilder()
					val operatingSystems = Set(OperatingSystem.IOS)
					
					// When
					builder.screen()
					builder.connectivity()
					builder.operatingSystem(operatingSystems)
					val device: Device = builder.build()
					
					// Then
					println(s"""SmartphoneBuilder produced: $device""")
					
					assertFalse(device.screen.isEmpty())
					assertFalse(device.connectivity.isEmpty)
					assertFalse(device.operatingSystems.isEmpty)
					assertEquals(device.operatingSystems, operatingSystems)
	}
	
	@Test
	def buildLaptopTest() = {
			// Given
			val builder: DeviceBuilderSimple = new LaptopBuilder()
					val operatingSystems = Set(OperatingSystem.LINUX, OperatingSystem.WINDOWS)
					
					// When
					builder.screen()
					builder.connectivity()
					builder.operatingSystem(operatingSystems)
					val device: Device = builder.build()
					
					// Then
					println(s"""LaptopBuilder produced: $device""")
					
					assertFalse(device.screen.isEmpty())
					assertFalse(device.connectivity.isEmpty)
					assertFalse(device.operatingSystems.isEmpty)
					assertEquals(device.operatingSystems, operatingSystems)
	}
  
  @Test
  def buildSmartwatchTest() = {
    // Given
    val builder: DeviceBuilderSimple = new SmartphoneBuilder()
    val operatingSystems = Set(OperatingSystem.ANDROID_WEAR)
    
    // When
    builder.screen()
    builder.connectivity()
    builder.operatingSystem(operatingSystems)
		val device: Device = builder.build()
      
    // Then
    println(s"""SmartwatchBuilder produced: $device""")
    
    assertFalse(device.screen.isEmpty())
    assertFalse(device.connectivity.isEmpty)
    assertFalse(device.operatingSystems.isEmpty)
    assertEquals(device.operatingSystems, operatingSystems)
  }
}