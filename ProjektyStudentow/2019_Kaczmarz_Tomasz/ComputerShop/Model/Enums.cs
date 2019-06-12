namespace ComputerShop.Model
{
    public enum GPUType
    {
        RTX2080,
        GTX1060,
        RX580,
        RadeonVII
    }

    public enum CPUType
    {
        Core_i5,
        Core_i7,
        Ryzen3,
        Ryzen7
    }

    public enum MonitorType
    {
        Dell,
        Asus,
        AOC,
        Acer
    }

    public enum ComputerType
    {
        Gaming,
        Office,
        Home
    }

    public enum OrderType
    {
        BuyComputer,
        Complaint,
        Warranty
    }
}