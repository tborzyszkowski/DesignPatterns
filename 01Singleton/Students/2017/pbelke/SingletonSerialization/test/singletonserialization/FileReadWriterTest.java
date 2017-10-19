package singletonserialization;

import org.junit.Assert;
import org.junit.Test;

/**
 *
 * @author pbelke
 */
public class FileReadWriterTest {

    @Test
    public void testSingletonSerialization() throws Exception {
        Singleton instanceOne = Singleton.getInstance();
        FileReaderWriter.write(instanceOne);
        Singleton instanceTwo = (Singleton) FileReaderWriter.read();

        Assert.assertEquals(instanceOne.hashCode(), instanceTwo.hashCode());
    }
}
