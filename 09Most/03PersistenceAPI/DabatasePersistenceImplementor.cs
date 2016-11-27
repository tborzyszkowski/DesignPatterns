using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03PersistenceAPI {
    // Database concrete implementor
    public class DabatasePersistenceImplementor : PersistenceImplementor {

        public DabatasePersistenceImplementor() {
            // load database driver
        }
        public void deleteObject(long objectId) {
            // open database connection
            // remove record
        }
        public Object getObject(long objectId) {
            // open database connection 
            // read records
            // create object from record 
            return null;
        }

        public long saveObject(Object objectToSave) {
            // open database connection 
            // create records for fields inside the object
            return 0;
        }

    }
}
