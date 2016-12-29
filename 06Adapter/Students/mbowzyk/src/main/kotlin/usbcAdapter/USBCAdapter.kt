package adapter.usbcAdapter

import adapter.usbcAdapter.plugs.Ethernet
import adapter.usbcAdapter.plugs.HDMI
import adapter.usbcAdapter.plugs.MiniUSB
import adapter.usbcAdapter.plugs.USBC

class USBCAdapter (val clazz: Any = Any()) : UsbcInterface {

    init {
        when (clazz) {
            is USBC -> println("USBC is connected")
            is Ethernet -> println("ethernet is connected")
            is HDMI -> println("hdmi is connected")
            is MiniUSB -> println("mini usb is connected")
            else -> throw IllegalArgumentException("incompatible type")
        }
    }

    override fun sendData(data: String): Boolean {
        when (clazz) {
            is USBC -> return clazz.sendData(data)
            is Ethernet -> return clazz.sendData(data).status == 200
            is HDMI -> return clazz.sendVideoAndSound(data) == "send correctly"
            is MiniUSB -> return clazz.sendData(data)
        }
        println("something went wrong, please run away")
        return false
    }

    override fun getData(data: String): String {
        when (clazz) {
            is USBC -> return clazz.getData(data)
            is Ethernet -> return clazz.getData(data).responseData
            is HDMI -> return clazz.getConnection().toString()
            is MiniUSB -> return clazz.getData(data)
        }
        println("something went wrong, please run away")
        return "ERROR, RUN FOR YOUR LIFE"
    }

    override fun chargeIn(electricity: Int): Boolean {
        when (clazz) {
            is USBC -> {
                if (electricity != 20)
                    return clazz.chargeIn(20)
                else return clazz.chargeIn(electricity)
            }
            is MiniUSB -> {
                if (electricity != 5)
                    return clazz.chargeIn(5)
                else return clazz.chargeIn(electricity)
            }
            else -> {
                println("it's not supported and not necessary")
                return false
            }
        }
    }

    override fun chargeOut(electricity: Int): Int {
        when (clazz) {
            is USBC -> return clazz.chargeOut(electricity)
            is MiniUSB -> return clazz.chargeOut(electricity) * 4
            else -> {
                println("it's not supported and not necessary")
                return 0
            }
        }
    }
}