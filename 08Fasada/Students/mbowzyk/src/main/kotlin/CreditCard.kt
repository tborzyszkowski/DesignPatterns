package facade

data class CreditCard(
        val cardNO: Number = 0,
        val csv: Int = 123,
        val pin: String = "",
        val owner: String = "Jan Kowalski",
        val cartType: CartType = CartType.VISA,
        val bankType: BankType = BankType.idea)