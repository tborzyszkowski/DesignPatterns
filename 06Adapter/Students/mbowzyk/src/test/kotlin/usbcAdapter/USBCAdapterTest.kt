package adapter.usbcAdapter

import adapter.usbcAdapter.plugs.Ethernet
import adapter.usbcAdapter.plugs.HDMI
import adapter.usbcAdapter.plugs.MiniUSB
import adapter.usbcAdapter.plugs.USBC
import org.junit.Assert.assertFalse
import org.junit.Assert.assertTrue
import org.junit.Test

class USBCAdapterTest {

    val fixtures = Fixtures()

    @Test
    fun sendData() {
        val dataToSend = "some data to send"
        assertTrue(fixtures.usbcInAdapter.sendData(dataToSend))
        assertTrue(fixtures.miniUsbInAdapter.sendData(dataToSend))
        assertTrue(fixtures.HdmiInAdapter.sendData(dataToSend))
        assertTrue(fixtures.EthernetInAdapter.sendData(dataToSend))
    }

    @Test
    fun getData() {
        val dataToGet = "some data to get from"
        println(fixtures.usbcInAdapter.getData(dataToGet))
        println(fixtures.miniUsbInAdapter.getData(dataToGet))
        println(fixtures.HdmiInAdapter.getData(dataToGet))
        println(fixtures.EthernetInAdapter.getData(dataToGet))
    }

    @Test
    fun chargeIn() {
        val electricity = 20
        assertTrue(fixtures.usbcInAdapter.chargeIn(electricity))
        assertTrue(fixtures.miniUsbInAdapter.chargeIn(electricity))
        assertFalse(fixtures.HdmiInAdapter.chargeIn(electricity))
        assertFalse(fixtures.EthernetInAdapter.chargeIn(electricity))
    }

    @Test
    fun chargeOut() {
        val electricity = 20
        assertTrue(fixtures.usbcInAdapter.chargeOut(electricity) == 20)
        assertTrue(fixtures.miniUsbInAdapter.chargeOut(electricity) == 20)
        assertTrue(fixtures.HdmiInAdapter.chargeOut(electricity) == 0)
        assertTrue(fixtures.EthernetInAdapter.chargeOut(electricity) == 0)
    }

    class Fixtures {
        val usbcInAdapter: UsbcInterface = USBCAdapter(USBC())
        val miniUsbInAdapter: UsbcInterface = USBCAdapter(MiniUSB())
        val HdmiInAdapter: UsbcInterface = USBCAdapter(HDMI())
        val EthernetInAdapter: UsbcInterface = USBCAdapter(Ethernet())
    }
}