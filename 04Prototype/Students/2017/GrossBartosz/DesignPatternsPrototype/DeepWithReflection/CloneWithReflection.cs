using System;
using System.Reflection;

namespace DesignPatternsPrototype.DeepWithReflection
{
    public static class CloneWithReflection
    {
        public static object CloneProcedure(this Object obj)
        {
            if (obj == null)
            {
                return null;
            }

            Type type = obj.GetType();

            if (type.IsPrimitive || type.IsEnum || type == typeof(string))
            {
                return obj;
            }

            if (type.IsClass || type.IsValueType)
            {
                object copiedObject = Activator.CreateInstance(obj.GetType());

                PropertyInfo[] fields = type.GetProperties();
                foreach (PropertyInfo field in fields)
                {
                    object fieldValue = field.GetValue(obj);
                    if (fieldValue != null)
                    {
                        field.SetValue(copiedObject, CloneProcedure(fieldValue));
                    }

                }
                return copiedObject;
            }

            throw new ArgumentException("The object is unknown type");
        }
    }
}
