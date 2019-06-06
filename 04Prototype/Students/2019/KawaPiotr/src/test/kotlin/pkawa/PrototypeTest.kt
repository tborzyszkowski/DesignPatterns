package pkawa

import org.junit.Assert.*
import org.junit.Test

class PrototypeTest {
    @Test
    fun deepCopyTest() {
        val obj1 = ConsoleShop.getConsolePrototype("PS4")
        val obj2 = ConsoleShop.getConsolePrototype("PS4")


        println("$obj1")
        println("$obj2")

        assertFalse("Objects reference should be different", obj1 === obj2)
        assertTrue("Objects are equal, hash code is the same", obj1 == obj2)
    }


    @Test
    fun shallowCopyTest() {
        val obj1 = ConsoleShop.getConsoleShallowCopy("PS4")
        val obj2 = ConsoleShop.getConsoleShallowCopy("PS4")


        assertFalse("Objects reference should be different", obj1 === obj2)
        assertSame(obj1.pad, obj2.pad)
        assertSame(obj1.games, obj2.games)
        assertSame(obj1.console, obj2.console)
    }
}