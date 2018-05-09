package com.mposluszny.dp.builder.domain

object Connectivity extends Enumeration {
  type Connectivity = Value
	val GSM = Value("GSM")
	val WIFI = Value("Wi-Fi")
	val BLUETOOTH = Value("Bluetooth")
}