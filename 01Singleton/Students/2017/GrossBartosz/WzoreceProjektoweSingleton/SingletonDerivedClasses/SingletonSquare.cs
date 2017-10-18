using WzoreceProjektoweSingleton.SingletonBase;
using WzoreceProjektoweSingleton.Interfaces;

namespace WzoreceProjektoweSingleton.SingletonDerivedClasses
{
    /// <summary>
    /// The Singleton Square class inherit from Singleton
    /// </summary>
    public class SingletonSquare : Singleton, ICalculate
    {
        #region Fileds constans and properties

        /// <summary>
        /// The object name.
        /// </summary>
        private readonly string name = "Child Singleton Square";

        /// <summary>
        /// The side value.
        /// </summary>
        public double Side { get; set; }

        /// <summary>
        /// Gets the proper singleton instance.
        /// </summary>
        public static SingletonSquare Squareingleton
        {
            get
            {
                return Nested.ReturnInstance();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize singleton rectangle
        /// </summary>
        private SingletonSquare() {}

        #endregion

        #region Methods

        /// <summary>
        /// The Get Shape Value.
        /// </summary>
        /// <param name="values">
        /// The params
        /// </param>
        /// <returns>
        /// Returns the <see cref="double"/>
        /// </returns>
        public double GetShapeValue(params double[] values)
        {
            return Side * 2;
        }

        #endregion

        #region Override of Singleton

        /// <summary>
        /// The overrided Get Name method.
        /// </summary>
        public override string GetName()
        {
            return $"Object:{name}";
        }

        #endregion

        #region Nested class

        /// <summary>
        /// The Nested class.
        /// </summary>
        private class Nested
        {
            /// <summary>
            /// Explicit static constructor to tell C# compiler, not to mark type as beforefieldinit.
            /// </summary>
            static Nested()
            {
            }

            /// <summary>
            /// The singleton instance.
            /// </summary>
            private static SingletonSquare instance = null;

            /// <summary>
            /// The nested class method which retrun singleton object.
            /// </summary>
            /// <returns>
            /// The <see cref="SingletonSquare "/>
            /// </returns>
            public static SingletonSquare ReturnInstance()
            {
                if (instance == null)
                {
                    instance = new SingletonSquare();
                }
                Id++;
                return instance;
            }
        }
        #endregion

    }

}
