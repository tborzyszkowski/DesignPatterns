namespace FabrykaRefleksja
{
    using System;
    using System.Reflection;

    public abstract class CarShop
    {
        public static Car GetCar<T>() where T : Car
        {
            return Activator.CreateInstance<T>();
        }

        public static Car GetCar(string carName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(carName).FullName;
            return (Car)Activator.CreateInstanceFrom(assembly.Location, type).Unwrap();
        }
    }
}
