package facade

import facade.banks.Allior
import facade.banks.BankInterface
import facade.banks.Idea
import facade.banks.MBank
import facade.cards.MasterCard
import facade.cards.Visa

class CashMachine {

    fun getCash(creditCard: CreditCard, pin: String, amount: Double): String {
        if (pin.length < 4)
            throw IllegalArgumentException("WRONG PIN")

        when (creditCard.cartType) {
            CartType.VISA -> Visa().authorize(creditCard.csv, pin, creditCard.owner)
            CartType.MASTERCARD -> MasterCard().authorize(creditCard.csv, pin, creditCard.owner)
            else -> throw IllegalArgumentException("SOMETHING WENT WRONG, WAIT FOR POLICE")
        }

        val customerBank: BankInterface
        when (creditCard.bankType) {
            BankType.mBank -> customerBank = MBank()
            BankType.Allior -> customerBank = Allior()
            BankType.idea -> customerBank = Idea()
            else -> throw IllegalArgumentException("UNKNOWN BANK TYPE, PLEASE WAIT FOR POLICE")
        }

        if (!customerBank.
                checkIfThereIsEnoughMoney
                (cardNo = creditCard.cardNO, customer = creditCard.owner, amount = amount))
            return "sorry, you don't have muney, go be poor somewhere else"
        customerBank.commitTransaction(amount)

        return "please, have yours ${amount}, still You have ${customerBank.getCustomerSavings()}"
    }
}