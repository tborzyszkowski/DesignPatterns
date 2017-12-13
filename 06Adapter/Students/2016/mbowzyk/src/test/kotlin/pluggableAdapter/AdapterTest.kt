package adapter.pluggableAdapter

import org.junit.Test

class AdapterTest {

    @Test
    fun connectWithClassFromConstructor() {
        val adaptHDMI = Adapter(HDMI::class)
        println("data: ${adaptHDMI.connectWithClassFromConstructor()}")

        val adaptUSBC = Adapter(USBtypeC::class)
        println("data: ${adaptUSBC.connectWithClassFromConstructor()}")

        val adaptMDP = Adapter(MiniDisplayPort::class)
        println("data: ${adaptMDP.connectWithClassFromConstructor()}")
    }

    @Test
    fun connectWithGivenClass() {
        val adapter: Adapter = Adapter()

        println("hdmi data: ${adapter.connectWithGivenClass<HDMI>()}")
        println("usbc data: ${adapter.connectWithGivenClass<USBtypeC>()}")
        println("mdp data: ${adapter.connectWithGivenClass<MiniDisplayPort>()}")
    }

    @Test
    fun connectWithClassFromConstructorUsingSmartCast() {
        val adaptHDMI = AnotherAdapter(HDMI())
        println("data: ${adaptHDMI.connectWithClassFromConstructorInDifferentWay()}")

        val adaptUSBC = AnotherAdapter(USBtypeC())
        println("data: ${adaptUSBC.connectWithClassFromConstructorInDifferentWay()}")

        val adaptMDP = AnotherAdapter(MiniDisplayPort())
        println("data: ${adaptMDP.connectWithClassFromConstructorInDifferentWay()}")
    }
}