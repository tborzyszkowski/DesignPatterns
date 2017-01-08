package facade

import org.junit.Test

class CashMachineTest {

    @Test
    fun getCash() {
        val cashMachine = CashMachine()

        val creditCardFromAllior = CreditCard(
                cardNO = 986675521,
                csv = 1234,
                pin = "9876",
                owner = "Mariusz BuziaNocnik",
                cartType = CartType.VISA,
                bankType = BankType.Allior)

        println(cashMachine.getCash(creditCard = creditCardFromAllior, pin = "9876", amount = 20.00))
        println()

        val creditCardFromIdea = CreditCard(
                cardNO = 986675521,
                csv = 1234,
                pin = "9876",
                owner = "Mariusz BuziaNocnik",
                cartType = CartType.VISA,
                bankType = BankType.idea)

        println(cashMachine.getCash(creditCard = creditCardFromIdea, pin = "9876", amount = 500.00))
        println()

        val creditCardFromMBank = CreditCard(
                cardNO = 986675521,
                csv = 1234,
                pin = "9876",
                owner = "Mariusz BuziaNocnik",
                cartType = CartType.MASTERCARD,
                bankType = BankType.mBank)

        println(cashMachine.getCash(creditCard = creditCardFromMBank, pin = "9876", amount = 1000.00))
    }
}