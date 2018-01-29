using DesignPatternsProject.Interfaces;

namespace DesignPatternsProject.Decorator
{
    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    internal abstract class Decorator : IDecoratorFunctionality
    {
        protected BaseTcpClientInfo ConnectedClientInfo;

        protected Decorator(BaseTcpClientInfo client)
        {
            ConnectedClientInfo = client;
        }

        public abstract void SetClientName(string newName);
    }
}