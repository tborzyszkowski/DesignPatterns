package singleton

@SerialVersionUID(100L)
class SerializationSafeSingleton private(var state: Int) extends Serializable {
  def increment(): Unit = {
    state += 1
  }

  def readResolve(): Object = {
    SerializationSafeSingleton.instance
  }
}

object SerializationSafeSingleton {
  //Lazy values in Scala can hold null values. Access to lazy value is thread-safe.
  lazy val instance = new SerializationSafeSingleton(0)

}


