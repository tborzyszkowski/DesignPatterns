
namespace _02Managers {
	class Purchase {
		public int Number { get; set; }
		public double Amount { get; set; }
		private string Purpose { get; set; }

		// Constructor
		public Purchase(int number, double amount, string purpose) {
			this.Number = number;
			this.Amount = amount;
			this.Purpose = purpose;
		}
	}
}
