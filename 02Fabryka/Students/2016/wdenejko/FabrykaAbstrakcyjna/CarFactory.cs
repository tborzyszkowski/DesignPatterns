using System;
namespace FabrykaAbstrakcyjna
{
	abstract class CarFactory
	{
		public abstract Ford CreateFord();
		public abstract Audi CreateAudi();
	}
}
