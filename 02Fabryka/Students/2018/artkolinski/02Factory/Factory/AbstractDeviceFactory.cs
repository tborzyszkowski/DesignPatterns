using System;
using System.Threading;
using Factory.Models;

namespace Factory
{
    public abstract class DeviceFactory
    {
        public abstract Device Create();
    }
    public class SmartphoneFactory : DeviceFactory
    {
        public override Device Create()
        {
            Thread.Sleep(300);
            return Activator.CreateInstance<Smartphone>();
        }
    }
    public class SmartphoneFactory2 : DeviceFactory
    {
        public override Device Create()
        {
            Thread.Sleep(100);
            return Activator.CreateInstance<Smartphone>();
        }
    }
    public class TabletFactory : DeviceFactory
    {
        public override Device Create()
        {
            return Activator.CreateInstance<Tablet>();
        }
    }
    public class BookReaderFactory : DeviceFactory
    {
        public override Device Create()
        {
            return Activator.CreateInstance<BookReader>();
        }
    }

}
