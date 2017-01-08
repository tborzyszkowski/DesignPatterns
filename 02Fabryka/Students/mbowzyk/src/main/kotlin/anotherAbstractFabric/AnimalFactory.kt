package fabric.anotherAbstractFabric

import fabric.anotherAbstractFabric.models.*

abstract class AnimalFactory {

    abstract fun getAnimal(): Animal

    companion object {
        inline fun <reified T : Animal> createAnimal(): Animal =
                when (T::class) {
                    Dog::class -> DogFactory().getAnimal()
                    Cat::class -> CatFactory().getAnimal()
                    else -> throw IllegalArgumentException()
                }
    }
}