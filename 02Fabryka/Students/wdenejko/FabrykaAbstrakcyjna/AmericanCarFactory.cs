using System;
namespace FabrykaAbstrakcyjna
{
	class AmericanCarFactory : CarFactory
	{
		public override Ford CreateFord()
		{
			return new FordGt();
		}
		public override Audi CreateAudi()
		{
			return new AudiRS();
		}
	}
}
