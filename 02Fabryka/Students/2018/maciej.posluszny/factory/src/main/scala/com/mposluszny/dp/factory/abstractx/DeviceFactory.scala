package com.mposluszny.dp.factory.abstractx

import com.mposluszny.dp.factory.domain.Device

trait DeviceFactory {
  def getDeviceWithWifiAndLinux(): Device
  def getDeviceWithWifiBluetoothAndAndroid(): Device
  def getDefaultDevice(): Device
  def getDeviceWithNoOS(): Device
  def getDeviceWithBluetooth(): Device
}