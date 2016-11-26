using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03PersistenceAPI {
    // Abstraction Interface
    public interface Persistence {

        String persist(Object objectToPesist);

        Object findById(String objectId);

        void deleteById(String id);
    }
}
