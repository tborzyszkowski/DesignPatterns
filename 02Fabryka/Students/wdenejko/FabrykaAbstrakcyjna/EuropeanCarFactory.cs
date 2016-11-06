using System;
namespace FabrykaAbstrakcyjna
{
	class EuropeanCarFactory : CarFactory
	{
		public override Ford CreateFord()
		{
			return new FordFiesta();	
		}
		public override Audi CreateAudi() 
		{
			return new AudiA3();
		}
	}
}
