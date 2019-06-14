package pkawa.chain

import pkawa.abstractfactory.PlatformFactory

interface FactoryChain {
    var nextInChain: FactoryChain?
    fun findFactory(consoleName: String): PlatformFactory?
}