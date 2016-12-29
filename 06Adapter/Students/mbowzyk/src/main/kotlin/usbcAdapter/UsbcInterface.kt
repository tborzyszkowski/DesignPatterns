package adapter.usbcAdapter

interface UsbcInterface {

    fun sendData(data: String): Boolean
    fun getData(data: String): String
    fun chargeIn(electricity: Int): Boolean
    fun chargeOut(electricity: Int): Int
}