package prototype

import org.junit.Test

class EmployeesTest {

    @Test
    fun cloneEmployees() {
        val employees: Employees = Employees()
        employees.loadData()
        println("first employees list ${employees.employeeList}")

        val employees2: Employees = employees.clone()
        println("second employees list ${employees2.employeeList}")

        employees.employeeList.remove("marian")
        employees2.employeeList.add("maciek")

        println("first employees list ${employees.employeeList} with removed marian")
        println("second employees list ${employees2.employeeList} with added maciek")
    }
}