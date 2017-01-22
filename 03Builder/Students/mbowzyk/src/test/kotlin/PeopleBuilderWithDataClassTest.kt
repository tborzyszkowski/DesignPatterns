package builder

import builder.usingDataClass.Alien
import builder.usingDataClass.PeopleBuilder
import builder.usingDataClass.Person
import org.junit.Test

class PeopleBuilderWithDataClassTest {

    @Test
    fun createPerson() {
        val andrzej: Person = PeopleBuilder().name("Andrzej").lastName("Lepper").age(69).build()
        println(andrzej)

        val jarek: Person = PeopleBuilder("Jarek", "Donald").age(70).isAlive(true).build()
        println(jarek)

        val buzia: Person = PeopleBuilder("Mariusz", "Buzianocnik", 40).isAlive(true).build()
        println(buzia)

        val noName: Person = PeopleBuilder().build()
        println(noName)
    }

    @Test
    fun createAlienWithOnlyDataClass() {
        val defaultAlien: Alien = Alien()
        println(defaultAlien)

        val superman: Alien =
                Alien(species = "kryptonian", name = "Superman", age = 25, isAlive = true)
        println(superman)
    }
}