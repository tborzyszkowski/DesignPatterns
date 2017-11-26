package prototype.deepCloning

class EmployeesController constructor() {

    var employeesList: MutableList<Employee> = mutableListOf()

    constructor(employeesList: MutableList<Employee>): this() {
        this.employeesList = employeesList
    }

    fun loadData() {
        employeesList.add(
                Employee(name = "Marian", lastName = "Marian",
                        position = Position(name = "senior dev", money = 15000),
                        address = Address(city = "Gdańsk", street = "witosa", number = "1A")))
        employeesList.add(
                Employee(name = "Andrzej", lastName = "Adud",
                        position = Position(name = "junior dev", money = 1.00),
                        address = Address(city = "Gdańsk", street = "beach", number = "1")))

        employeesList.add(
                Employee(name = "Krzysztof", lastName = "Marian",
                        position = Position(name = "middle dev", money = 9000.50),
                        address = Address(city = "Warszawa", street = "wiejska", number = "666")))

        employeesList.add(
                Employee(name = "Stefan", lastName = "Andrzej",
                        position = Position(name = "cleaning dev", money = 666.666),
                        address = Address(city = "Gdynia")))
    }

    fun clone(): EmployeesController {
        val newList = employeesList.map { it -> it.copy() }

        return EmployeesController(newList.toMutableList())
    }
}