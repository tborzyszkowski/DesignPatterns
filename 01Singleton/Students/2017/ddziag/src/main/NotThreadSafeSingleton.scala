package singleton

class NotThreadSafeSingleton private(var state: Int) {
  def inc = state += 1
}

object NotThreadSafeSingleton {
  private var _instance: NotThreadSafeSingleton = _

  def instance: NotThreadSafeSingleton = {
    if (_instance == null) _instance = new NotThreadSafeSingleton(0)
    _instance
  }
}