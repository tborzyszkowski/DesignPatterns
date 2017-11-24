package singleton

class ScalaLikeThreadsafeSingleton private(var state: Int) {
  def inc = state += 1
}

/**
  * In scala, an object is initialized in static block so thread safety is guaranteed by JVM (Java static initializers are thread safe)
  */
object ScalaLikeThreadsafeSingleton {
  //Access to lazy value is thread-safe.
  lazy val instance: ScalaLikeThreadsafeSingleton = new ScalaLikeThreadsafeSingleton(0)

}