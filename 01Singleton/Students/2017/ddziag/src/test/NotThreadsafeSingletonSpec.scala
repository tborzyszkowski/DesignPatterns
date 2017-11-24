package singleton

import java.util.concurrent.{ExecutorService, Executors}

import org.scalatest.FunSpec

import scala.collection.mutable
import scala.util.Random


class NotThreadsafeSingletonSpec extends FunSpec {

  class UnsafeThread() extends Runnable {
    var hc: Int = 0

    override def run(): Unit = {
      val ins = NotThreadSafeSingleton.instance
      val r: Int = Random.nextInt(100)
      hc = ins.hashCode()
      UnsafeThread.instances += ins
    }
  }

  object UnsafeThread {
    val instances = mutable.Set.empty[NotThreadSafeSingleton]

  }

  describe("NotThreadSafeSingleton") {
    it("should return same instance") {
      val instance1 = NotThreadSafeSingleton.instance
      val instance2 = NotThreadSafeSingleton.instance
      assert(instance1.hashCode() == instance2.hashCode())
    }
    it("should return same number on both instances ") {
      val instance1 = NotThreadSafeSingleton.instance
      val instance2 = NotThreadSafeSingleton.instance
      instance1.inc
      instance2.inc
      assert(instance1.state == 2)
      assert(instance2.state == 2)
    }
  }
  describe("testy w izolacji ") {
    it("should have more than 1 instance with multiple threads") {
      val pool: ExecutorService = Executors.newFixedThreadPool(100)
      val pool2: ExecutorService = Executors.newFixedThreadPool(100)
      for (i <- 1 to 1000) {
        pool.execute(new UnsafeThread)
        pool2.execute(new UnsafeThread)
      }
      assert(UnsafeThread.instances.size > 1)
    }
  }

}