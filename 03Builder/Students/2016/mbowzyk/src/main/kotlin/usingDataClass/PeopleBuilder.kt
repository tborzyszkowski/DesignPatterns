package builder.usingDataClass

class PeopleBuilder constructor(){

    constructor(name: String, lastName: String) : this() {
        this.name = name
        this.lastName = lastName
    }

    constructor(name: String, lastName: String, age: Number) : this(name, lastName) {
        this.age = age
    }

    private var name: String = "no name"
    private var lastName: String = "no last name"
    private var age: Number = 0
    private var isAlive: Boolean = false

    fun name(name: String): PeopleBuilder {
        this.name = name
        return this
    }

    fun lastName(lastName: String): PeopleBuilder {
        this.lastName = lastName
        return this
    }

    fun age(age: Number): PeopleBuilder {
        this.age = age
        return this
    }

    fun isAlive(isAlive: Boolean): PeopleBuilder {
        this.isAlive = isAlive
        return this
    }

    fun build() : Person = Person(name = name, lastName = lastName, age = age, isAlive = isAlive)
}