package builder.typicalClassUsingMappingFromBuilder

class Person(val name: String, val lastName: String, val age: Number, val isAlive: Boolean) {

    private constructor(builder: Builder) : this(builder.name, builder.lastName, builder.age, builder.isAlive)

    companion object {
        fun create(init: Builder.() -> Unit) = Builder(init).build()
    }

    override fun toString(): String {
        return "person ${name} ${lastName} age ${age} and alive ${isAlive}"
    }

    class Builder private constructor() {

        constructor(init: Builder.() -> Unit) : this() {
            init()
        }

        var name: String = "No Name"
        var lastName: String = "No LastName"
        var age: Int = 0
        var isAlive: Boolean = false

        fun name(init: Builder.() -> String) = apply { name = init() }

        fun lastName(init: Builder.() -> String) = apply { lastName = init() }

        fun age(init: Builder.() -> Int) = apply { age = init() }

        fun isAlive(init: Builder.() -> Boolean) = apply { isAlive = init() }

        fun build() = Person(this)
    }
}