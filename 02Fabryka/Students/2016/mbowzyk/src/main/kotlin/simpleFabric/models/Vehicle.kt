package fabric.simpleFabric.models

open class Vehicle() {
    protected var marka:String = ""
    protected var silnik:String = ""
    protected var model:String = ""

    override fun toString(): String {
        return "marka : ${marka} silnik : ${silnik} model : ${model}"
    }

    override fun hashCode(): Int {
        val prepHash:String = marka.plus(silnik).plus(model)

        return prepHash.hashCode()
    }

}
