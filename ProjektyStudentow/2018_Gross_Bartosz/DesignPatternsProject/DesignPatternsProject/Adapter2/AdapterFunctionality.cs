using DesignPatternsProject.Communication;
using DesignPatternsProject.Interfaces;

namespace DesignPatternsProject.Adapter
{
    public class ServerFunctionality
    {
        public void StartOption()
        {
            var singleMode = new SingleCommunication();
            var adapter = new CommunicationAdapter(singleMode);

            Tester(adapter);
        }

        private static void Tester(IBaseCommunication adapter)
        {
            adapter.CreatServer();
        }
    }

    public class CommunicationAdapter : IBaseCommunication
    {
        private readonly ICommunication _communication;

        public CommunicationAdapter(ICommunication communication)
        {
            _communication = communication;
        }

        public void CreatServer()
        {
            _communication.CreatServer();
        }

        public void CloseServer()
        {
            _communication.CloseServer();
        }
    }
}