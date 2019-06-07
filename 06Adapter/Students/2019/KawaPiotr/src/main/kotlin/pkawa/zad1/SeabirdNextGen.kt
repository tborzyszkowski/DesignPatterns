package pkawa.zad1

class SeabirdNextGen : Aircraft(), ISeacraft {
    override var airborne: Boolean = false
        get() = height > 50
    override var speed: Int = 0
        private set

    override fun takeOff() {
        while (!this.airborne)
            increaseRevs()
    }

    override fun increaseRevs() {
        this.speed += 10
        println("Seacraft engine increases revs to " + this.speed + " knots")
        if (this.speed > 40) {
            this.height += 100
        }
    }
}