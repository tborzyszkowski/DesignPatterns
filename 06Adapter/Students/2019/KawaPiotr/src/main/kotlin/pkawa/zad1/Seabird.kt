package pkawa.zad1

class Seabird : Seacraft(), IAircraft {
    override val airborne: Boolean
        get() = height > 50

    override var height: Int = 0
        private set

    // A two-way adapter hides and routes the Target's methods
    // Use Seacraft instructions to implement this one
    override fun takeOff() {
        while (!airborne) {
            increaseRevs()
        }
    }

    // This method is common to both Target and Adaptee
    override fun increaseRevs() {
        super.increaseRevs()
        if (speed > 40) {
            height += 100
        }
    }
}