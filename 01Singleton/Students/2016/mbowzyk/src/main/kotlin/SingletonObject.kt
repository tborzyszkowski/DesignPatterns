package singleton

object SingletonObject {

    init {
        println("singleton object ($this)")
    }

    var testText:String? = null
    var counter:Int = 0
}