using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03PersistenceAPI {
    class MainApp {
        static void Main(string[] args) {

            PersistenceImplementor implementor = null;

            if (databaseDriverExists()) {
                implementor = new DabatasePersistenceImplementor();
            }
            else {
                implementor = new FileSystemPersistenceImplementor();
            }

            Persistence persistenceAPI = new PersistenceImp(implementor);
            Object o = persistenceAPI.findById("12343755");
            // do changes to the object 
            // then persist
            persistenceAPI.persist(o);
            // can also change implementor
            persistenceAPI = new PersistenceImp(new DabatasePersistenceImplementor());
            persistenceAPI.deleteById("2323");
        }
        private static bool databaseDriverExists() {
            return false;
        }
    }
}
