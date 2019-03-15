package singletontest;

import static org.junit.Assert.assertTrue;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutput;
import java.io.ObjectOutputStream;
import java.nio.file.DirectoryNotEmptyException;
import java.nio.file.Files;
import java.nio.file.NoSuchFileException;
import java.nio.file.Paths;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import serialization.SerializedSingleton;

public class TestSingletonSerialization {
	
	private SerializedSingleton instanceOne;
	private SerializedSingleton instanceTwo = null;
	
	@Before
	public void executeBeforeEach() {
		instanceOne = SerializedSingleton.getInstance();
	}

	@Test
	public void serializationTest() throws FileNotFoundException {
		
		try(ObjectOutput out = new ObjectOutputStream(new FileOutputStream("file.txt"))){
			out.writeObject(instanceOne);
			out.close();
			
		}catch(FileNotFoundException e) {
			e.printStackTrace();
		}catch(IOException e) {
			e.printStackTrace();
		}
		try(ObjectInput in = new ObjectInputStream(new FileInputStream("file.txt"))){
			instanceTwo = (SerializedSingleton)in.readObject();
			in.close();
		}catch(FileNotFoundException e) {
			e.printStackTrace();
		}catch(IOException e) {
			e.printStackTrace();
		}catch(ClassNotFoundException e) {
			e.printStackTrace();
		}
		assertTrue(instanceOne.hashCode() == instanceTwo.hashCode());
	}
	
	@After
	public void executeAfterTest() {
		instanceOne = null;
		instanceTwo = null;
		try
        { 
            Files.deleteIfExists(Paths.get("file.txt")); 
        } 
        catch(NoSuchFileException e) 
        { 
        	e.printStackTrace();
        } 
        catch(DirectoryNotEmptyException e) 
        { 
        	e.printStackTrace();
        } 
        catch(IOException e) 
        { 
        	e.printStackTrace();
        } 
	}
	
}