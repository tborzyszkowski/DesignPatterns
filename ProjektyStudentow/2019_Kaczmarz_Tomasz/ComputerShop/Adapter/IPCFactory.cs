using ComputerShop.Model;

namespace ComputerShop.Adapter
{
    interface IPCFactory
    {
        Computer CreateComputer(ComputerType type);
    }
}
