package adapter.usbcAdapter.plugs

import adapter.usbcAdapter.UsbcInterface

class USBC : UsbcInterface {

    override fun sendData(data: String): Boolean = true

    override fun getData(data: String): String = data.plus(" via usbc")

    override fun chargeIn(electricity: Int): Boolean = electricity == 20

    override fun chargeOut(electricity: Int): Int = 20
}