package builder

import builder.typicalClassUsingMappingFromBuilder.Person
import org.junit.Test

class PeopleBuilderWithMappingTest {

    @Test
    fun buildSomePeople() {
        val andrzej: Person = Person.create {
            name { "Jarek" }
            lastName { "Donal" }
            age { 70 }
            isAlive { true }
        }
        println(andrzej.toString())

        val jarek: Person = Person.create {
            name = "Andrzej"
            lastName = "Lepper"
            age = 69
            isAlive = true
        }
        println(jarek.toString())
    }
}