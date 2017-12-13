package singleton;

import java.util.Collections;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class SingletonTest {

	@Test
	public void getMultipleTimesInDifferentThreadsInstancesOfSingletonAndPrintResult() throws InterruptedException {
		int times = 100;
		Set<Singleton> instances = Collections.newSetFromMap(new ConcurrentHashMap<>());
		ExecutorService executorService = Executors.newFixedThreadPool(times);
		long start = System.currentTimeMillis();
		for (int i = 0; i < times; i++) {
			executorService.execute(() -> {
				Singleton instance = Singleton.getInstance();
				instances.add(instance);
			});
		}
		executorService.shutdown();
		executorService.awaitTermination(1, TimeUnit.MINUTES);
		long end = System.currentTimeMillis();

		System.out.println(
				"getting " + times + " times instance of " + Singleton.class + ": " + instances + " in " + (end - start)
						+ " milliseconds");

		assertEquals(2, instances.size());
	}

	@Test
	public void getMultipleTimesInstancesOfSingletonAndPrintResult() throws InterruptedException {
		int times = 1000000;
		long start = System.currentTimeMillis();
		for (int i = 0; i < times; i++) {
			Singleton.getInstance();
		}
		long end = System.currentTimeMillis();

		System.out.println("getting " + times + " times instance of " + Singleton.class + " in " + (end - start)
				+ " milliseconds");
	}

}