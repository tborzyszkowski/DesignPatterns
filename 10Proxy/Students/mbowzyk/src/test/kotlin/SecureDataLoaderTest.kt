package proxy

import org.junit.Test

class SecureDataLoaderTest {

    @Test
    fun useSecureDataLoader() {
        val securedDataLoader = SecureDataLoader("password")
        println(securedDataLoader.readData("some path"))

        val securedDataLoaderWithWrongPassword = SecureDataLoader("buka")
        println(securedDataLoaderWithWrongPassword.readData("some path"))
    }
}