package prototype.deepCloning

data class Employee (
        val name: String = "No name",
        val lastName: String = "No last name",
        val position: Position,
        val address: Address)