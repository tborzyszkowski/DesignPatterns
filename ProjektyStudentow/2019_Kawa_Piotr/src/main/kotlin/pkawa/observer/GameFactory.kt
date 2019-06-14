package pkawa.observer

import pkawa.model.Game

interface GameFactory {
    val shops: List<GameShopObserver>
    fun register(shop: GameShopObserver)
    fun unregister(shop: GameShopObserver)
    fun notifyShops(game: Game)
}