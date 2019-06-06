package pkawa

import java.time.LocalDate
import java.util.*

object ConsoleShop {
    private val consoleRetailBoxes = hashMapOf(
        "PS4" to ConsoleRetailBox(
            Console("Playstation 4", LocalDate.of(2013, Calendar.NOVEMBER, 15), Platform.PS4),
            arrayListOf(Game("Knack", Platform.PS4)),
            arrayListOf(ConsoleController("Black", isSymmetric = true))
        ),
        "PS4 PRO" to ConsoleRetailBox(
            Console("Playstation 4 Pro", LocalDate.of(2016, Calendar.NOVEMBER, 10), Platform.PS4),
            arrayListOf(Game("Knack 2", Platform.PS4)),
            arrayListOf(ConsoleController("Black", isSymmetric = true))
        ),
        "SWITCH" to ConsoleRetailBox(
            Console("Nintendo Switch", LocalDate.of(2017, Calendar.MARCH, 3), Platform.SWITCH),
            arrayListOf(Game("Zelda: Breath of the Wild", Platform.SWITCH)),
            arrayListOf(ConsoleController("Neon blue & red", isSymmetric = false))
        ),
        "XBONE" to ConsoleRetailBox(
            Console("Xbox One", LocalDate.of(2013, Calendar.NOVEMBER, 22), Platform.XBOX),
            arrayListOf(Game("Forza Horizon", Platform.XBOX)),
            arrayListOf(ConsoleController("White", isSymmetric = false))
        )
    )

    fun getConsolePrototype(type: String) = consoleRetailBoxes[type]!!.clone()
    fun getConsoleShallowCopy(type: String) = consoleRetailBoxes[type]!!.shallowCopy()
}