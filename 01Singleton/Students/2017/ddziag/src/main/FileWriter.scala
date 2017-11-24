package singleton

import java.io._


object FileWriter {

  def write(fn: String, obj: Object): Unit = {
    val oos = new ObjectOutputStream(new FileOutputStream(fn))
    oos.writeObject(obj)
    oos.flush()
  }

  def read(fn: String): Singleton = {
    val ois = new ObjectInputStream(new FileInputStream(fn))
    val s = ois.readObject().asInstanceOf[Singleton]
    ois.close()
    s
  }

}