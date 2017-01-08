package proxy

class DataLoader : DataLoaderInterface {

    override fun readData(path: String): String = "reading from ${path}"
}