package fabric.anotherAbstractFabric

import fabric.anotherAbstractFabric.models.Animal
import fabric.anotherAbstractFabric.models.Cat

class CatFactory : AnimalFactory() {

    override fun getAnimal(): Animal = Cat()
}