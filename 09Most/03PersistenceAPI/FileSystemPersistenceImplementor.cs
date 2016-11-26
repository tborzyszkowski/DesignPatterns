using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03PersistenceAPI {
    // Concrete Implementor
    public class FileSystemPersistenceImplementor : PersistenceImplementor {

        public void deleteObject(long objectId) {
            File.Delete(@".\persistence\" + objectId.ToString());
        }

        public Object getObject(long objectId) {
            FileInfo f = new FileInfo(@".\persistence\" + objectId.ToString());
            return readObjectFromFile(f);
        }

        private Object readObjectFromFile(FileInfo f) {
            // open file 
            // and load object 
            //return the object
            return null;
        }

        public long saveObject(Object objectToSave) {

            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            long fileId = (long)ts.TotalMilliseconds;
            
            // open file 
            FileInfo f = new FileInfo(@".\persistence\" + fileId.ToString());
       
            // write file to Streanm 
            writeObjectToFile(f, objectToSave);

            return fileId;
        }

        private void writeObjectToFile(FileInfo f, Object objectToSave) {
            // serialize object and write it to file
        }
    }
}
