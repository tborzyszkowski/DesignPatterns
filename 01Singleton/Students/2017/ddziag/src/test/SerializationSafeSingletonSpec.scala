package singleton

import org.scalatest.FunSpec

class SerializationSafeSingletonSpec extends FunSpec {


  describe("SerializationSafeSingleton") {
    it("should have same instance created twice ") {
      val s1 = SerializationSafeSingleton.instance
      val s2 = SerializationSafeSingleton.instance
      assert(s1.hashCode() == s2.hashCode())
    }
    it("2 serialized instances should have same hashcode ") {
      val s1 = SerializationSafeSingleton.instance
      val s2 = SerializationSafeSingleton.instance

      FileWriter.write("s1", s1)
      FileWriter.write("s2", s2)

      val s3 = FileWriter.read("s1")
      val s4 = FileWriter.read("s1")
      val s5 = FileWriter.read("s2")
      val s6 = FileWriter.read("s2")
      assert(s3.hashCode() == s4.hashCode())
      assert(s3.hashCode() == s5.hashCode())
      assert(s3.hashCode() == s6.hashCode())
      assert(s4.hashCode() == s5.hashCode())
      assert(s4.hashCode() == s6.hashCode())

    }
  }
}
