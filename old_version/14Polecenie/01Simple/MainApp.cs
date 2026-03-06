
namespace _01Simple {
	class MainApp {
		static void Main(string[] args) {
			Receiver receiver = new Receiver();
			Command command = new ConcreteCommand(receiver);
			Invoker invoker = new Invoker();

			invoker.SetCommand(command);
			invoker.ExecuteCommand();
		}
	}
}
