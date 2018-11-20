using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace PrototypePattern.Helpers
{
    internal class DeepCopier
    {
        private readonly object objectToBeCloned;
        private readonly Type typeOfObject;

        private const BindingFlags Binding =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy;

        public DeepCopier(object objectToBeCloned)
        {
            if (objectToBeCloned == null)
                throw new ArgumentNullException(nameof(objectToBeCloned));

            this.objectToBeCloned = objectToBeCloned;
            this.typeOfObject = objectToBeCloned.GetType();
        }

        public object Copy()
        {
            object copied = Activator.CreateInstance(this.typeOfObject, true);

            if (this.objectToBeCloned is IList listObject)
            {
                var copiedListObject = copied as IList;
                foreach (object item in listObject)
                {
                    object value = item != null ? new DeepCopier(item).Copy() : null;
                    copiedListObject.Add(value);
                }
            }
            else
            {
                var fields = new List<FieldInfo>();
                Type type = this.typeOfObject;
                while (type != null)
                {
                    fields.AddRange(type.GetFields(Binding));
                    type = type.BaseType;
                }

                foreach (FieldInfo fieldInfo in fields)
                {
                    object value = fieldInfo.GetValue(this.objectToBeCloned);
                    if (fieldInfo.FieldType == typeof(string))
                    {
                        value = string.Copy((string)value);
                    }
                    else if (value != null && !fieldInfo.FieldType.IsValueType)
                    {
                        value = new DeepCopier(value).Copy();
                    }
                    fieldInfo.SetValue(copied, value);
                }
            }
            return copied;
        }
    }
}
