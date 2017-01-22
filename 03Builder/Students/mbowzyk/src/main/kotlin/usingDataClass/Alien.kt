package builder.usingDataClass

data class Alien (
        val species: String = "human",
        val name: String = "Batman",
        val age: Number = 40,
        val isAlive: Boolean = true)