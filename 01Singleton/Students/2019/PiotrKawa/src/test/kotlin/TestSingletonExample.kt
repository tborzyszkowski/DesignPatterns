import org.junit.Assert.assertEquals
import org.junit.Test
import java.io.*
import java.util.concurrent.Executors
import kotlin.collections.HashSet

class TestSingletonExample {

    @Test fun alwaysSameInstanceReturned() {
        val instance1 = SingletonExample.getInstance()
        val instance2 = SingletonExample.getInstance()

        assertEquals("Always the same instance is returned. ", instance1.hashCode(), instance2.hashCode())
    }

    @Test fun serializationKeepsSingletonContract() {
        val instance1 = SingletonExample.getInstance()

        val serialized = ObjectOutputStream(FileOutputStream("exampletestfile") as OutputStream?)
        serialized.writeObject(instance1)
        serialized.close()

        val deserialized = ObjectInputStream(FileInputStream("exampletestfile"))
        val instance2 : SingletonExample = deserialized.readObject() as SingletonExample
        deserialized.close()
        File("exampletestfile").delete()

        assertEquals("Object are properly serialized/deserialized.", instance1.hashCode(), instance2.hashCode())
    }

    @Test fun checkIfMultithreadedProgramReturnsTheSameInstance() {
        val threadsAmount = 200
        val executorService = Executors.newFixedThreadPool(threadsAmount)
        val singletonPool = HashSet<SingletonExample>()
        val expectedPoolSize = 1 // only 1 exists

        repeat(threadsAmount) {
            executorService.execute {
                val singleton = SingletonExample.getInstance()
                singletonPool.add(singleton)
            }
        }
        executorService.shutdown()


        assertEquals("Only 1 unique element should be in set.", expectedPoolSize, singletonPool.size)
    }
}