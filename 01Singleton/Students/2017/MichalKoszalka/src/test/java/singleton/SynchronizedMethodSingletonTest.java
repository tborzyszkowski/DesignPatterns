package singleton;

import java.util.Collections;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class SynchronizedMethodSingletonTest {

	@Test
	public void getMultipleTimesInstancesInDifferentThreadsOfSynchronizedMethodSingletonAndPrintResult()
			throws InterruptedException {
		int times = 1000;
		Set<SynchronizedMethodSingleton> instances = Collections.newSetFromMap(new ConcurrentHashMap<>());
		ExecutorService executorService = Executors.newFixedThreadPool(times);
		long start = System.currentTimeMillis();
		for (int i = 0; i < times; i++) {
			executorService.execute(() -> {
				SynchronizedMethodSingleton instance = SynchronizedMethodSingleton.getInstance();
				instances.add(instance);
			});
		}
		executorService.shutdown();
		executorService.awaitTermination(1, TimeUnit.MINUTES);
		long end = System.currentTimeMillis();

		System.out.println(
				"getting " + times + " times instance of " + SynchronizedMethodSingleton.class + ": " + instances
						+ " in " + (end - start) + " milliseconds");

		assertEquals(1, instances.size());	}

	@Test
	public void getMultipleTimesInstancesOfSynchronizedMethodSingletonAndPrintResult() throws InterruptedException {
		int times = 1000000;
		long start = System.currentTimeMillis();
		for (int i = 0; i < times; i++) {
			SynchronizedMethodSingleton.getInstance();
		}
		long end = System.currentTimeMillis();

		System.out.println(
				"getting " + times + " times instance of " + SynchronizedMethodSingleton.class + " in " + (end - start)
						+ " milliseconds");
	}

}