package fabric

import fabric.anotherAbstractFabric.AnimalFactory
import fabric.anotherAbstractFabric.models.Cat
import fabric.anotherAbstractFabric.models.Dog
import org.junit.Test

class AnimalFactoryTest {

    @Test
    fun getSomePet() {
        val dog = AnimalFactory.createAnimal<Dog>()
        println(dog.sound())

        val cat = AnimalFactory.createAnimal<Cat>()
        println(cat.sound())
    }
}