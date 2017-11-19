package singleton

import java.util.concurrent.{ExecutorService, Executors}

import org.scalatest.FunSpec

class ScalaVersusJavaTimeSpec extends FunSpec {


  class JavaThread() extends Runnable {
    override def run(): Unit = {
      val ins = JavaLikeThreadsafeSingleton.instance
    }
  }

  class ScalaThread() extends Runnable {
    override def run(): Unit = {
      val ins = ScalaLikeThreadsafeSingleton.instance
    }
  }

  describe("measurments of getting instances with multiple threads") {

    it("withouth pool scala <= java") {
      def measureJavaPool(debug: Boolean = false)(implicit pool: ExecutorService): Long = {
        val startSafe = System.currentTimeMillis()
        if (debug) println(s"Started safe measurement: ${System.currentTimeMillis()}")
        for (i <- 1 to 10000) {
          new JavaThread().run()
        }
        val endSafe = System.currentTimeMillis()
        if (debug) println(s"Ended safe measurement: ${System.currentTimeMillis()}")
        val safeTime = endSafe - startSafe
        if (debug) println(s"safe(time) = ${safeTime}")
        safeTime
      }

      def measureScalaPool(debug: Boolean = false)(implicit pool: ExecutorService): Long = {
        if (debug) println(s"Started safe measurement: ${System.currentTimeMillis()}")
        val startSafe = System.currentTimeMillis()
        for (i <- 1 to 10000) {
          new ScalaThread().run()
        }
        val endSafe = System.currentTimeMillis()
        if (debug) println(s"Ended safe measurement: ${System.currentTimeMillis()}")
        val safeTime = endSafe - startSafe
        if (debug) println(s"safe(time) = ${safeTime}")
        safeTime
      }

      implicit val pool: ExecutorService = Executors.newFixedThreadPool(10)
      val scalaTime = measureScalaPool()
      val javaTime = measureJavaPool()
      println(s"scala time = (${scalaTime}) : java time = (${javaTime})")

      assert(scalaTime >= javaTime)
    }
    it("with pool scala < java") {
      def measureJavaPool(debug: Boolean = false)(implicit pool: ExecutorService): Long = {
        val startSafe = System.currentTimeMillis()
        if (debug) println(s"Started safe measurement: ${System.currentTimeMillis()}")
        for (i <- 1 to 10000) {
          pool.execute(new JavaThread())
        }
        val endSafe = System.currentTimeMillis()
        if (debug) println(s"Ended safe measurement: ${System.currentTimeMillis()}")
        val safeTime = endSafe - startSafe
        if (debug) println(s"safe(time) = ${safeTime}")
        safeTime
      }

      def measureScalaPool(debug: Boolean = false)(implicit pool: ExecutorService): Long = {
        if (debug) println(s"Started safe measurement: ${System.currentTimeMillis()}")
        val startSafe = System.currentTimeMillis()
        for (i <- 1 to 10000) {
          pool.execute(new ScalaThread())
        }
        val endSafe = System.currentTimeMillis()
        if (debug) println(s"Ended safe measurement: ${System.currentTimeMillis()}")
        val safeTime = endSafe - startSafe
        if (debug) println(s"safe(time) = ${safeTime}")
        safeTime
      }

      implicit val pool: ExecutorService = Executors.newFixedThreadPool(10)
      val scalaTime = measureScalaPool()
      val javaTime = measureJavaPool()

      println(s"scala time = (${scalaTime}) : java time = (${javaTime})")
      assert(scalaTime > javaTime)
    }
  }
}
