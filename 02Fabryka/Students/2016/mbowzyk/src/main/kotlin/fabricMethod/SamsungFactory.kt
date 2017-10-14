package fabric.fabricMethod

import fabric.fabricMethod.models.Phone
import fabric.fabricMethod.models.SamsungA7
import fabric.fabricMethod.models.SamsungE6
import fabric.fabricMethod.models.SamsungE7
import fabric.fabricMethod.models.SamsungNote7

class SamsungFactory : PhoneFactory() {

    override fun buildPhone(phoneModel: PhoneModel): Phone {
        val phone: Phone

        when (phoneModel) {
            PhoneModel.SAMSUNG_E6 -> phone = SamsungE6()
            PhoneModel.SAMSUNG_A7 -> phone = SamsungA7()
            PhoneModel.SAMSUNG_E7 -> phone = SamsungE7()
            PhoneModel.SAMSUNG_NOTE7 -> phone = SamsungNote7()
            else -> {
                throw IllegalArgumentException("wrong model type for Samsung")
            }
        }

        return phone
    }
}