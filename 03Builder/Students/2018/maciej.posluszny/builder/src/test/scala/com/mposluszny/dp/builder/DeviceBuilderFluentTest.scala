package com.mposluszny.dp.builder

import org.junit._
import Assert._
import com.mposluszny.dp.builder.domain.Device
import com.mposluszny.dp.builder.domain.OperatingSystem
import com.mposluszny.dp.builder.domain.DeviceImplicits._ // implicit conversion for Device
import com.mposluszny.dp.builder.fluent.DeviceBuilderFluent
import com.mposluszny.dp.builder.fluent.LaptopBuilder
import com.mposluszny.dp.builder.fluent.SmartphoneBuilder
import com.mposluszny.dp.builder.fluent.SmartwatchBuilder

class DeviceBuilderFluentTest {
  
  @Test
  def buildSmartphoneTest() = {
    // Given
    val builder: DeviceBuilderFluent = new SmartphoneBuilder()
    val operatingSystems = Set(OperatingSystem.ANDROID)
    
    // When
		val device: Device = builder
		  .screen()
      .connectivity()
      .operatingSystem(operatingSystems)
//      .build() // return Device explicitly
      
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
    val builder: DeviceBuilderFluent = new LaptopBuilder()
    val operatingSystems = Set(OperatingSystem.LINUX, OperatingSystem.WINDOWS)
    
    // When
		val device: Device = builder
		  .screen()
      .connectivity()
      .operatingSystem(operatingSystems)
//      .build() // return Device explicitly
      
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
    val builder: DeviceBuilderFluent = new SmartwatchBuilder()
    val operatingSystems = Set(OperatingSystem.ANDROID)
    
    // When
		val device: Device = builder
		  .screen()
      .connectivity()
      .operatingSystem(operatingSystems)
//      .build() // return Device explicitly
      
      // Then
      println(s"""SmartwatchBuilder produced: $device""")
      
      assertFalse(device.screen.isEmpty())
      assertFalse(device.connectivity.isEmpty)
      assertFalse(device.operatingSystems.isEmpty)
      assertEquals(device.operatingSystems, operatingSystems)
  }
}