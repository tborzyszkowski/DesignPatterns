using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03PersistenceAPI {
    public interface PersistenceImplementor {
        // Implementor Interface 
        long saveObject(Object objectToSave);

        void deleteObject(long objectId);

        Object getObject(long objectId);
    }
}
