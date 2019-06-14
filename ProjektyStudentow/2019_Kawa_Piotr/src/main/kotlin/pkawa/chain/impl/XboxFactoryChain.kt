package pkawa.chain.impl

import pkawa.abstractfactory.PlatformFactory
import pkawa.abstractfactory.impl.XboxOneFactory
import pkawa.chain.FactoryChain

class XboxFactoryChain : FactoryChain {
    override var nextInChain: FactoryChain? = null

    override fun findFactory(consoleName: String): PlatformFactory? {
        return if (consoleName.startsWith("Xbox One")) {
            XboxOneFactory.INSTANCE
        } else {
            nextInChain?.findFactory(consoleName)
        }
    }

}