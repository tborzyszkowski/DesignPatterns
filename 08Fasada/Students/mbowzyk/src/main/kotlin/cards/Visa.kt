package facade.cards

class Visa : CardInterface {

    override fun authorize(csv: Int, pin: String, owner: String): Boolean {
        //do something
        println("using Visa")
        return csv > 100
    }
}