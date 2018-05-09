package com.mposluszny.dp.prototype.domain

object OperatingSystem extends Enumeration {
  type OperatingSystem = String
  val WINDOWS = "Windows"
  val LINUX = "Linux"
  val ANDROID = "Android"
  val ANDROID_WEAR = "Android Wear"
  val IOS = "iOS"
}