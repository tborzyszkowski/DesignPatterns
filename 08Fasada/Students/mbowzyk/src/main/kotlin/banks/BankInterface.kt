package facade.banks

interface BankInterface {

    var customer: Customer?

    fun checkIfThereIsEnoughMoney(cardNo: Number, customer: String, amount: Double): Boolean
    fun commitTransaction(amount: Double): Boolean
    fun getCustomerSavings(): Double
}
