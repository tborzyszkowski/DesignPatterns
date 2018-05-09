package com.mposluszny.dp.factory.domain

object OperatingSystem extends Enumeration {
  type OperatingSystem = Value
  val WINDOWS = Value("Windows")
  val LINUX = Value("Linux")
  val ANDROID = Value("Android")
  val ANDROID_WEAR = Value("Android Wear")
  val IOS = Value("iOS")
  val MACOS = Value("MacOS")
}