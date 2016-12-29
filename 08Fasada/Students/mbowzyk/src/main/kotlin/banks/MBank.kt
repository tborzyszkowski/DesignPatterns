package facade.banks

class MBank : BankInterface {
    override var customer: Customer? = null

    override fun checkIfThereIsEnoughMoney(cardNo: Number, customer: String, amount: Double): Boolean {
        println("checking in mbank")
        getCustomer(customer)
        println(this.customer)
        return amount < this.customer!!.amount
    }

    override fun commitTransaction(amount: Double): Boolean {
        println("mbank doing their job")
        if (customer != null) {
            customer!!.amount -= amount
            return true
        }
        else return false
    }

    private fun getCustomer(customerName: String) {
        customer = Customer(name = customerName,
                amount = Math.random() * (2000 - 100) + 100)
    }

    override fun getCustomerSavings(): Double {
        if (customer != null) return customer!!.amount
        else return 0.00
    }
}
