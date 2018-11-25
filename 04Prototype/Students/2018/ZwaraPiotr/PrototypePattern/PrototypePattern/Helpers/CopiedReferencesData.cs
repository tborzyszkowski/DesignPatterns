using System.Collections.Generic;
using System.Linq;

namespace PrototypePattern.Helpers
{
    internal class CopiedReferencesData
    {
        private readonly Dictionary<int, List<(object OriginalObject, object ClonedObject)>> data;

        public CopiedReferencesData()
        {
            this.data = new Dictionary<int, List<(object OriginalObject, object ClonedObject)>>();
        }

        public void Add(object originalObject, object clonedObject)
        {
            int hashCode = originalObject.GetHashCode();

            if (this.data.ContainsKey(hashCode))
            {
                this.data[hashCode].Add((originalObject, clonedObject));
            }
            else
            {
                this.data.Add(hashCode, new List<(object OriginalObject, object ClonedObject)>
                {
                    (originalObject, clonedObject)
                });
            }
        }

        public (bool Success, object ClonedObject) TryGet(object originalObject)
        {
            int hashCode = originalObject.GetHashCode();
            if (this.data.TryGetValue(hashCode, out List<(object OriginalObject, object ClonedObject)> value))
            {
                (object OriginalObject, object ClonedObject) match =
                    value.FirstOrDefault(v => ReferenceEquals(v.OriginalObject, originalObject));
                if (match.ClonedObject != null)
                    return (true, match.ClonedObject);
            }
            return (false, null);
        }
    }
}
