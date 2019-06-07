package pkawa.registered.reflection

import pkawa.model.Console
import pkawa.model.ConsoleCodename

object ReflectionConsoleFactory {
    val registeredConsoles : HashMap<ConsoleCodename, Class<*>> = hashMapOf()

    fun registerConsole(consoleCodename: ConsoleCodename, consoleClass: Class<*>) {
        registeredConsoles[consoleCodename] = consoleClass
    }

    fun createConsole(consoleCodename: ConsoleCodename) : Console? {
        val consoleClass = registeredConsoles[consoleCodename]
        val consoleConstructor = consoleClass?.getConstructor()
        return consoleConstructor?.newInstance() as Console?
    }
}