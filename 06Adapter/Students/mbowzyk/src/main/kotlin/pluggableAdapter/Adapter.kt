package adapter.pluggableAdapter

class Adapter (){

    var clazz: Any = Any::class

    constructor(clazz: Any): this() {
       this.clazz = clazz
    }

    inline fun <reified T> connectWithGivenClass(): String {
        when (T::class) {
            HDMI::class -> return HDMI().sendSoundAndVideo().plus(" with additional data from adapter")
            USBtypeC::class -> return USBtypeC().sendData()
            MiniDisplayPort::class -> return MiniDisplayPort().sendVideoAndSound()
            else -> throw IllegalArgumentException("incompatible type")
        }
    }

    fun connectWithClassFromConstructor(): String {
        when (clazz) {
            HDMI::class -> return HDMI().sendSoundAndVideo().plus(addSomeDataToHDMI())
            USBtypeC::class -> return USBtypeC().sendData()
            MiniDisplayPort::class -> return MiniDisplayPort().sendVideoAndSound()
            else -> throw IllegalArgumentException("incompatible type")
        }
    }

    private fun addSomeDataToHDMI(): String = " with additional data from adapter"
}