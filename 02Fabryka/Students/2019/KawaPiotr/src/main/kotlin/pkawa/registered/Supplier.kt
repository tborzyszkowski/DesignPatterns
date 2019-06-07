package pkawa.registered

import pkawa.model.Console
import pkawa.model.PlayStation4
import java.util.function.Supplier

class PlayStationSupplier : Supplier<Console> {
    override fun get(): Console = PlayStation4()
}