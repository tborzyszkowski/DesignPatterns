package adapter.usbcAdapter.plugs

class MiniUSB {

    fun sendData(data: String): Boolean  {
        println("it will take a while, because mini usb")
        return true
    }

    fun getData(data: String): String {
        println("it's not that fast in mini usb")
        return data.plus(" via mini usb")
    }

    fun chargeIn(electricity: Int): Boolean {
        println("via mini usb it will take longer")
        return electricity == 5
    }

    fun chargeOut(electricity: Int): Int {
        println("You have no power here - Darth Sidious about mini usb")
        return 5
    }
}