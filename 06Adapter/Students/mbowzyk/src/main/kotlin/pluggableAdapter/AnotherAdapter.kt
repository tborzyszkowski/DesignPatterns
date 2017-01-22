package adapter.pluggableAdapter

class AnotherAdapter (val clazz: Any = Any()) {

    fun connectWithClassFromConstructorInDifferentWay(): String {
        when (clazz) {
            is HDMI -> return clazz.sendSoundAndVideo().plus(addSomeDataToHDMI())
            is USBtypeC -> return clazz.sendData()
            is MiniDisplayPort -> return clazz.sendVideoAndSound()
            else -> throw IllegalArgumentException("incompatible type")
        }
    }

    private fun addSomeDataToHDMI(): String = " with additional data from adapter"
}