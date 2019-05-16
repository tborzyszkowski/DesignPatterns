package pkawa.registered

import pkawa.model.Console
import pkawa.model.ConsoleCodename
import java.util.function.Supplier

object ConsoleFactory {
    private val registeredConsoles: HashMap<ConsoleCodename, Supplier<Console>> = hashMapOf()

    fun registerConsole(consoleCodename: ConsoleCodename, supplier: Supplier<Console>) {
        registeredConsoles[consoleCodename] = supplier
    }

    fun createConsole(consoleCodename: ConsoleCodename) : Console? =
        registeredConsoles[consoleCodename]?.get()

}