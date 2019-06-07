package pkawa.zad1

open class Seacraft : ISeacraft {
    override var speed: Int = 0
        protected set

    override fun increaseRevs() {
        speed += 10
        println("Seacraft engine increases revs to $speed knots")
    }
}