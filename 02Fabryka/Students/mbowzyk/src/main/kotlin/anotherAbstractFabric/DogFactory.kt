package fabric.anotherAbstractFabric

import fabric.anotherAbstractFabric.models.Animal
import fabric.anotherAbstractFabric.models.Dog

class DogFactory : AnimalFactory(){

    override fun getAnimal(): Animal = Dog()
}