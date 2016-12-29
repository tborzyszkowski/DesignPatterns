package proxy

class SecureDataLoader (val password: String) : DataLoaderInterface{

    val dataLoader = DataLoader()

    override fun readData(path: String): String {
        if (password == "password") {
            println("password correct, access granted")
            return dataLoader.readData(path)
        }
        else {
            println("wrong password for this operation, access refused")
            return ""
        }
    }
}