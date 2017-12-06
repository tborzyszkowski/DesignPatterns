package prototype

class Employees constructor(){

    var employeeList: MutableList<String> = mutableListOf()

    constructor(employeeList: MutableList<String>): this() {
        this.employeeList = employeeList
    }

    fun loadData() {
        employeeList.add("andrzej")
        employeeList.add("marian")
        employeeList.add("krzysztof")
        employeeList.add("stefan")
    }

    fun clone(): Employees {
        val newList: MutableList<String> = mutableListOf()
        newList.addAll(employeeList)

        return Employees(newList)
    }
}