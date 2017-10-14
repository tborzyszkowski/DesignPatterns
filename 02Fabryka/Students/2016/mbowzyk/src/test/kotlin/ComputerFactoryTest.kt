package fabric

import fabric.abstractFabric.ComputerFactory
import fabric.abstractFabric.factories.*
import fabric.abstractFabric.LaptopType
import fabric.abstractFabric.models.Computer
import org.junit.Test

class ComputerFactoryTest {

    @Test
    fun createPCServerAndLaptops() {
        val computerFactory: ComputerFactory = ComputerFactory()
        var concreteComputerFactory: ComputerFactoryInterface

        concreteComputerFactory = PCFactory()
        val pc: Computer = computerFactory.createComputer(concreteComputerFactory)
        concreteComputerFactory = ServersFactory()
        val server: Computer = computerFactory.createComputer(concreteComputerFactory)
        concreteComputerFactory = LaptopFactory()
        val defautLaptop: Computer = computerFactory.createComputer(concreteComputerFactory)
        concreteComputerFactory = LaptopFactory(LaptopType.NETBOOK)
        val netbook: Computer = computerFactory.createComputer(concreteComputerFactory)
        concreteComputerFactory = LaptopFactory(LaptopType.NOTEBOOK)
        val notebook: Computer = computerFactory.createComputer(concreteComputerFactory)
        concreteComputerFactory = LaptopFactory(LaptopType.ULTRABOOK)
        val ultrabook: Computer = computerFactory.createComputer(concreteComputerFactory)
    }
}