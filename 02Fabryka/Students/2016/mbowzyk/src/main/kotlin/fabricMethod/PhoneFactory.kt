package fabric.fabricMethod

import fabric.fabricMethod.models.Phone

abstract class PhoneFactory {

    abstract protected fun buildPhone(phoneModel: PhoneModel) : Phone

    fun orderPhone(phoneModel: PhoneModel) : Phone {
        val phone: Phone = buildPhone(phoneModel)
        println("creating phone ${phone.toString()}")
        phone.prepare().building().packing()
        println("phone is ready ${phone.toString()}")

        return phone
    }

}