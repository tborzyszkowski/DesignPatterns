package singleton

class SingletonClass private constructor(){

    init {
        println("initialized singleton ($this)")
    }

    private object Holder {
        val INSTANCE = SingletonClass()
    }

    companion object {
        val instance : SingletonClass by lazy { Holder.INSTANCE }
    }

    var testText:String? = null
    var counter:Int = 0
}