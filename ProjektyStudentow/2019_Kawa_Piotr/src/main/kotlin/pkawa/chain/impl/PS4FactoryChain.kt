package pkawa.chain.impl

import pkawa.abstractfactory.PlatformFactory
import pkawa.abstractfactory.impl.PlaystationFactory
import pkawa.chain.FactoryChain

class PS4FactoryChain : FactoryChain {
    override var nextInChain: FactoryChain? = null

    override fun findFactory(consoleName: String): PlatformFactory? {
        return if (consoleName.startsWith("Playstation 4")) {
            PlaystationFactory.INSTANCE
        } else {
            nextInChain?.findFactory(consoleName)
        }
    }

}