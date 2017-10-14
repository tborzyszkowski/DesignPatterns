package fabric.abstractFabric

import fabric.abstractFabric.factories.ComputerFactoryInterface
import fabric.abstractFabric.models.Computer

class ComputerFactory {

    fun createComputer (computerFactory: ComputerFactoryInterface) : Computer =
            computerFactory.buildComputer()
}