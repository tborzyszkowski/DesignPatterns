package fabric.abstractFabric.factories

import fabric.abstractFabric.models.Computer

interface ComputerFactoryInterface {

    fun buildComputer() :Computer
}