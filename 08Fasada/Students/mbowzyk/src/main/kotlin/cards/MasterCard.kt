package facade.cards

class MasterCard : CardInterface {

    override fun authorize(csv: Int, pin: String, owner: String): Boolean {
        //do something
        println("using MasterCard")
        return csv > 100
    }
}