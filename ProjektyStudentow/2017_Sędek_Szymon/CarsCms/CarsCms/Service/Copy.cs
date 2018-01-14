namespace CarsCms.Service
{
    public class Copy
    {
        public static T Clone<T>(T obj) where T: class 
        {
            var inst = obj.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            return (T)inst?.Invoke(obj, null);
        }
    }
}