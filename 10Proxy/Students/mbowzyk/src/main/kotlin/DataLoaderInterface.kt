package proxy

interface DataLoaderInterface {

    fun readData(path: String): String
}