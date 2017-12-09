namespace WzoreceProjektoweSingleton.Interfaces
{
    public interface ICalculate
    {
        /// <summary>
        /// The get shape value.
        /// </summary>
        /// <param name="values">
        /// In the assumption variable use to get valus use to calculate shape area.
        /// </param>
        /// <returns></returns>
        double GetShapeValue(params double[] values);
    }
}
