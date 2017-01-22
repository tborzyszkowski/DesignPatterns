package fabric.fabricMethod

import fabric.fabricMethod.models.Iphone6S
import fabric.fabricMethod.models.Iphone6SP
import fabric.fabricMethod.models.Iphone7
import fabric.fabricMethod.models.Iphone7P
import fabric.fabricMethod.models.Phone

class AppleFactory : PhoneFactory() {

    override fun buildPhone(phoneModel: PhoneModel): Phone {
        val phone: Phone

        when (phoneModel) {
            PhoneModel.IPHONE_7 -> phone = Iphone7()
            PhoneModel.IPHONE_7P -> phone = Iphone7P()
            PhoneModel.IPHONE_6S -> phone = Iphone6S()
            PhoneModel.IPHONE_6SP -> phone = Iphone6SP()
            else -> {
                throw IllegalArgumentException("wrong model type for Apple")
            }
        }

        return phone
    }
}