
namespace _01Simple {
	class ConcreteCommand : Command {
		public ConcreteCommand(Receiver receiver) :
		  base(receiver) {
		}

		public override void Execute() {
			receiver.Action();
		}
	}
}
