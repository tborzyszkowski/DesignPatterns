package fabric

import fabric.fabricMethod.*
import fabric.fabricMethod.models.*
import junit.framework.Assert.assertTrue
import org.junit.Test

class PhoneFactoryTest {

    val fixtures:Fixtures = Fixtures()

    @Test
    fun shouldGeAppleDevices () {
        val appleFactory:PhoneFactory = AppleFactory()

        val iPhone7: Phone = appleFactory.orderPhone(PhoneModel.IPHONE_7)
        val iPhone7p:Phone = appleFactory.orderPhone(PhoneModel.IPHONE_7P)
        val iPhone6s:Phone = appleFactory.orderPhone(PhoneModel.IPHONE_6S)
        val iPhone6sp:Phone = appleFactory.orderPhone(PhoneModel.IPHONE_6SP)

        assertTrue(iPhone7.hashCode().equals(fixtures.iPhone7.hashCode()))
        assertTrue(iPhone7p.hashCode().equals(fixtures.iPhone7p.hashCode()))
        assertTrue(iPhone6s.hashCode().equals(fixtures.iPhone6s.hashCode()))
        assertTrue(iPhone6sp.hashCode().equals(fixtures.iPhone6sp.hashCode()))
    }

    @Test
    fun shouldGeSamsungDevices() {
        val samsungFactor:PhoneFactory = SamsungFactory()

        val samsungE6:Phone = samsungFactor.orderPhone(PhoneModel.SAMSUNG_E6)
        val samsungA7:Phone = samsungFactor.orderPhone(PhoneModel.SAMSUNG_A7)
        val samsungE7:Phone = samsungFactor.orderPhone(PhoneModel.SAMSUNG_E7)
        val samsungN7:Phone = samsungFactor.orderPhone(PhoneModel.SAMSUNG_NOTE7)

        assertTrue(samsungE6.hashCode().equals(fixtures.samsungE6.hashCode()))
        assertTrue(samsungA7.hashCode().equals(fixtures.samsungA7.hashCode()))
        assertTrue(samsungE7.hashCode().equals(fixtures.samsungE7.hashCode()))
        assertTrue(samsungN7.hashCode().equals(fixtures.samsungN7.hashCode()))
    }


    class Fixtures {
        val iPhone7:Iphone7 = Iphone7()
        val iPhone7p:Iphone7P = Iphone7P()
        val iPhone6s:Iphone6S = Iphone6S()
        val iPhone6sp:Iphone6SP = Iphone6SP()

        val samsungE6:SamsungE6 = SamsungE6()
        val samsungA7:SamsungA7 = SamsungA7()
        val samsungE7:SamsungE7 = SamsungE7()
        val samsungN7:SamsungNote7 = SamsungNote7()
    }
}