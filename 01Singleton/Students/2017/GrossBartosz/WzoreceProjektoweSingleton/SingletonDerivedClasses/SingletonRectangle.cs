using System;
using WzoreceProjektoweSingleton.SingletonBase;
using WzoreceProjektoweSingleton.Interfaces;

namespace WzoreceProjektoweSingleton.SingletonDerivedClasses
{
    /// <summary>
    /// The singleton rectangle class.
    /// </summary>
    public class SingletonRectangle : Singleton, ICalculate
    {
        #region Constructor
        /// <summary>
        /// Initialize singleton rectangle
        /// </summary>
        private SingletonRectangle() { }

        #endregion

        #region Fileds constans and properties

        /// <summary>
        /// The object name.
        /// </summary>
        private readonly string name = "Child Singleton Rectangle";

        /// <summary>
        /// Gets the proper singleton instance.
        /// </summary>
        public static SingletonRectangle RectangleSingleton
        {
            get
            {
                return Nested.ReturnInstance();
            }
        }

        /// <summary>
        /// The side value.
        /// </summary>
        public double FirstSide { get; set; }

        /// <summary>
        /// The side value.
        /// </summary>
        public double SecondSide { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// The get shape value.
        /// </summary>
        /// <param name="values">
        /// In the assumption variable use to get valus use to calculate shape area.
        /// </param>
        /// <returns></returns>
        public double GetShapeValue(params double[] values)
        {
            return FirstSide * SecondSide;
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
            private static SingletonRectangle instance = null;

            /// <summary>
            /// The nested class method which retrun singleton object.
            /// </summary>
            /// <returns>
            /// The <see cref="SingletonRectangle "/>
            /// </returns>
            public static SingletonRectangle ReturnInstance()
            {
                if (instance == null)
                {
                    instance = new SingletonRectangle();
                }
                Id++;
                return instance;
            }
        }
        #endregion
    }
}
