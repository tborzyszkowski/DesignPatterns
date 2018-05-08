package com.mposluszny.dp.prototype.domain

import org.junit._
import Assert._
import com.mposluszny.dp.prototype.DevicePrototypeFactory
import org.junit.runner.RunWith
import org.scalatest.junit.JUnitRunner
import junit.framework.TestSuite

class PrototypeTest {
  
  @Test
  def shallowCopyPrototypeTest = {
    // Given
    val prototype: Device = DevicePrototypeFactory.laptopPrototype()
    
    // When
		val concreteModel = prototype.shallowCopy()
    
    // Then
    assertNotNull(concreteModel.name)
    assertSame(prototype.name, concreteModel.name)
    
    assertNotNull(prototype.screen)
    assertNull(concreteModel.screen)
  }
  
  @Test
  def staticDeepCopyPrototypeTest = {
    // Given
    val prototype: Device = DevicePrototypeFactory.laptopPrototype()
    
    // When
		val concreteModel = prototype.deepCopyStatic()
    
    // Then
    assertNotNull(concreteModel.name)
    assertTrue(prototype.name.equals(concreteModel.name))
    
    assertNotNull(concreteModel.screen)
    assertNotSame(prototype.screen, concreteModel.screen)
    
    assertNotNull(concreteModel.screen.manufacturer)
    assertNotSame(prototype.screen.manufacturer, concreteModel.screen.manufacturer)
    
    assertNotNull(concreteModel.screen.manufacturer.name)
    assertTrue(prototype.screen.manufacturer.name.equals(concreteModel.screen.manufacturer.name))
  }
	
  @Test
  def deepCopyPrototypeTest = {
    // Given
    val prototype: Device = DevicePrototypeFactory.laptopPrototype()
    
    // When
		val concreteModel = prototype.deepCopy()
    
    // Then
    assertNotNull(concreteModel.name)
    assertTrue(prototype.name.equals(concreteModel.name))
    
    assertNotNull(concreteModel.screen)
    assertNotSame(prototype.screen, concreteModel.screen)
    
    assertNotNull(concreteModel.screen.manufacturer)
    assertNotSame(prototype.screen.manufacturer, concreteModel.screen.manufacturer)
    
    assertNotNull(concreteModel.screen.manufacturer.name)
    assertTrue(prototype.screen.manufacturer.name.equals(concreteModel.screen.manufacturer.name))
  }
}