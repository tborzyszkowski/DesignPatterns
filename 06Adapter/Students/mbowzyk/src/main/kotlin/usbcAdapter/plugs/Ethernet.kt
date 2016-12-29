package adapter.usbcAdapter.plugs

class Ethernet {

    fun sendData(data: String): EthernetResponse {
        println("send whatever You want, almost anywhere, via internet")
        return EthernetResponse(status = 200, responseData = "it was sent!!")
    }

    fun getData(data: String): EthernetResponse {
        println("get a lot of data from internet")
        return EthernetResponse(status = 200, responseData = data.plus(" some other data, and more!! from internet or other computer"))
    }
}