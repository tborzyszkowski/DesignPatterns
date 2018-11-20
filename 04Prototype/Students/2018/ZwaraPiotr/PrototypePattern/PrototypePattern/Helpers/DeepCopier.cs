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
        private readonly CopiedReferencesData data;

        private const BindingFlags Binding =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy;

        public DeepCopier(object objectToBeCloned, CopiedReferencesData data = null)
        {
            if (objectToBeCloned == null)
                throw new ArgumentNullException(nameof(objectToBeCloned));

            this.objectToBeCloned = objectToBeCloned;
            this.typeOfObject = objectToBeCloned.GetType();
            this.data = data ?? new CopiedReferencesData();
        }

        public object Copy()
        {
            object copied = Activator.CreateInstance(this.typeOfObject, true);

            if (this.IsAlreadyCopied(copied, out object alreadyCopiedObject))
                return alreadyCopiedObject;

            if (this.objectToBeCloned is IList listObject)
            {
                var copiedListObject = copied as IList;
                foreach (object item in listObject)
                {
                    object value = item != null ? new DeepCopier(item, this.data).Copy() : null;
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
                        value = new DeepCopier(value, this.data).Copy();
                    }
                    fieldInfo.SetValue(copied, value);
                }
            }
            return copied;
        }

        private bool IsAlreadyCopied(object newCopiedObject, out object alreadyCopiedObject)
        {
            bool isCopied = false;
            alreadyCopiedObject = null;

            if (!this.typeOfObject.IsValueType && this.typeOfObject != typeof(string))
            {
                (isCopied, alreadyCopiedObject) = this.data.TryGet(this.objectToBeCloned);
                if (!isCopied)
                    this.data.Add(this.objectToBeCloned, newCopiedObject);
            }

            return isCopied;
        }
    }
}
