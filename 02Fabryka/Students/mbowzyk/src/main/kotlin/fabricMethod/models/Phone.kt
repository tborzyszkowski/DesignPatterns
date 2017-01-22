package fabric.fabricMethod.models

open class Phone {
    protected var marka:String = ""
    protected var model:String = ""
    protected var system:String = ""
    protected var packed:Boolean = false

    fun prepare() : Phone {
        println("preparing ${marka} model ${model} with system ${system}")
        return this
    }

    fun building() : Phone {
        println("building ${marka} ${model}")
        return this
    }

    fun packing() : Phone {
        println("packing ${marka} ${model}")
        packed = true
        return this
    }

    override fun toString(): String {
        return "${marka} ${model} with ${system}, packed - ${packed}"
    }

    override fun hashCode(): Int {
        val prepHash:String = marka.plus(system).plus(model)

        return prepHash.hashCode()
    }
}