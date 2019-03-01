import java.io.Serializable

class SingletonExample private constructor() : Serializable {

    companion object {
        @JvmStatic private var singleton: SingletonExample? = null

        @Synchronized @JvmStatic fun getInstance() : SingletonExample {
            if (singleton == null) { singleton = SingletonExample() }
            return singleton!!
        }

    }

    init {
        if (singleton != null) {
            throw InstantiationError("This object already has one instance created")
        }
    }

    fun readResolve() = singleton as Any
}