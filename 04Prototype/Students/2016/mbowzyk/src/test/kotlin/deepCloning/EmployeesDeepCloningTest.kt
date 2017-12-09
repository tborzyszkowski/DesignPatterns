package prototype.deepCloning

import org.junit.Test

class EmployeesDeepCloningTest {

    @Test
    fun cloneEmployees() {
        val employees: EmployeesController = EmployeesController()
        employees.loadData()
        println("first employees list ${employees.employeesList}")

        val employees2: EmployeesController = employees.clone()
        println("second employees list ${employees2.employeesList}")

        employees.employeesList.removeAt(0)
        employees2.employeesList.add(
                employees2.employeesList.get(0).copy(name = "Maniek",
                        position = Position(name = "dev"))
        )
        println("first employees list ${employees.employeesList}")
        println("second employees list ${employees2.employeesList}")
    }
}