package singleton

import org.junit.Assert.assertTrue
import org.junit.Test

class SingletonTest {

    @Test
    fun testInitializationSolutionWithClass() {
        println("test class solution")
        var firstTime = SingletonClass.instance

        firstTime.testText = "some text"

        var secondTime = SingletonClass.instance

        assertTrue(secondTime.testText.equals(firstTime.testText))
    }

    @Test
    fun testInitializationSolutionWithObject() {
        println("test object solution")
        var firstTime = SingletonObject

        firstTime.testText = "some text"

        var secondTime = SingletonObject

        assertTrue(secondTime.testText.equals(firstTime.testText))
    }
}