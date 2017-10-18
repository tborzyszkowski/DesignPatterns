using WzoreceProjektoweSingleton.SingletonBase;
using WzoreceProjektoweSingleton.Interfaces;

namespace WzoreceProjektoweSingleton.SingletonDerivedClasses
{
    /// <summary>
    /// The Singleton Rectangle class inherit from Singleton
    /// </summary>
    public class GenericShape<TSingletonChild> where TSingletonChild : Singleton, ICalculate
    {
        /// <summary>
        /// The instance of generic type.
        /// </summary>
        private readonly TSingletonChild CurrentType;

        /// <summary>
        /// Initialize a new instance of <see cref="GenericShape{TSingletonChild} "/> class.
        /// </summary>
        /// <param name="singletionChild">
        /// The generic type.
        /// </param>
        public GenericShape(TSingletonChild singletionChild)
        {
            CurrentType = singletionChild;
        }

        /// <summary>
        /// The get objecy name method that return name of derived class.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>
        /// </returns>
        public string GetName()
        {
           return CurrentType.GetName();
        }

        /// <summary>
        /// The shape area method that in assumption calculate the shape area of derived class object.
        /// </summary>
        public void ShapeArea()
        {
            var result = CurrentType.GetShapeValue();
            CurrentType.AddMessage($" The result {result}");
        }
    }
}
