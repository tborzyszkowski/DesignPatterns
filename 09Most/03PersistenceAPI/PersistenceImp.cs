using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03PersistenceAPI {
    // Abstraction Imp
    public class PersistenceImp : Persistence {

    private PersistenceImplementor implementor = null;

    public PersistenceImp(PersistenceImplementor imp) {
        this.implementor = imp;
    }

    public void deleteById(String id) {
        implementor.deleteObject(Convert.ToInt64(id));
    }

    public Object findById(String objectId) {
        return implementor.getObject(Convert.ToInt64(objectId));
    }

    public String persist(Object objectToPesist) {

        return implementor.saveObject(objectToPesist).ToString();


    }

}
}
