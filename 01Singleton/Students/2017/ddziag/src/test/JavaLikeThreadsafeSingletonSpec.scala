package singleton

import java.util.concurrent.{ExecutorService, Executors}

import org.scalatest.FunSpec

import scala.collection.mutable
import scala.collection.mutable.ArrayBuffer
import scala.util.Random

class JavaLikeThreadsafeSingletonSpec extends FunSpec {

  class SafeThread() extends Runnable {
    var hc: Int = 0

    override def run(): Unit = {
      val ins = JavaLikeThreadsafeSingleton.instance
      val r: Int = Random.nextInt(100)
      hc = ins.hashCode()
      SafeThread.instances += ins
    }
  }

  object SafeThread {
    val instances = new mutable.HashSet[JavaLikeThreadsafeSingleton].empty
  }

  describe("JavaLikeThreadsafeSingleton") {
    it("every thread should have same hashcode of singleton and there should be only one instance") {
      val pool: ExecutorService = Executors.newFixedThreadPool(100)
      val pool2: ExecutorService = Executors.newFixedThreadPool(100)
      val hashCode: Int = JavaLikeThreadsafeSingleton.instance.hashCode()
      val threadList = ArrayBuffer.empty[SafeThread]
      for (i <- 1 to 1000) {
        val sf = new SafeThread()
        threadList += sf
        pool.execute(sf)
        pool2.execute(sf)
      }
      threadList.foreach(p => {
        assert(p.hc == hashCode)
      })

      assert(SafeThread.instances.size == 1)
    }
  }


}
