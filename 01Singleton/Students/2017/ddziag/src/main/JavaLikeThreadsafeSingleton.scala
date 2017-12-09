package singleton

class JavaLikeThreadsafeSingleton private(var state: Int) {
  def inc = state += 1
}


object JavaLikeThreadsafeSingleton {
  private var _instance: JavaLikeThreadsafeSingleton = _

  def instance: JavaLikeThreadsafeSingleton = {
    if (_instance == null) {
      synchronized {
        if (_instance == null) {
          _instance = new JavaLikeThreadsafeSingleton(0)
        }
      }
    }
    _instance
  }
}

