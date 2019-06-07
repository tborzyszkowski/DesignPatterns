package pkawa.zad1

open class Aircraft : IAircraft {
    override var airborne: Boolean = false
        protected set
    override var height: Int = 0
        protected set

    override fun takeOff() {
        println("Aircraft engine takeoff")
        airborne = true
        height = 200
    }
}