package adapter.usbcAdapter.plugs

class HDMI {

    fun sendVideoAndSound(data: String): String {
        println("must be in high resolution for hdmi")
        return "send correctly"
    }

    fun getConnection(): Boolean {
        println("checking, if it's connected")
        return true
    }
}