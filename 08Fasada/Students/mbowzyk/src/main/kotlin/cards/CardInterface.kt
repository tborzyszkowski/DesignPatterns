package facade.cards

interface CardInterface {

    fun authorize(csv: Int, pin: String, owner: String): Boolean
}