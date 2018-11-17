package com.mposluszny.dp.singleton;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class SingletonTest {
	
	@Before
	public void initEnumService() {
		NoteServiceEnum.INSTANCE.init(new ArrayList<>(Arrays.asList(
				new Note(1, "First note"),
				new Note(2, "Second note"),
				new Note(3, "Third note"),
				new Note(4, "Fourth note"),
				new Note(5, "Fifth note")
			)));
	}
	
	@Test
	public void check_if_class_singleton_is_thread_safe() throws InterruptedException, ExecutionException {
		// Given
		int n = 10;
		ExecutorService executor = Executors.newFixedThreadPool(n);
		
		Callable<NoteService> getNoteServiceTask = () -> {
			return NoteServiceClass.getInstance();
		};
		
		List<Future<NoteService>> results = new ArrayList<>();
		
		// When
		for (int i = 0; i < n; i++) {
			results.add(executor.submit(getNoteServiceTask));
		}
		
		// Then
		NoteService referenceService = results.get(0).get();
		
		Thread.sleep(100);
		boolean allReferencesMatch = results.stream()
			.map(future -> {
				NoteService noteService = null;
				try {
					noteService = future.get();
				} catch (InterruptedException | ExecutionException e) {
					e.printStackTrace();
				}
				return noteService;
			})
			.allMatch(service -> {
				return service == referenceService;
			});
		
		Assert.assertTrue("One or more references is different! Singleton property has not been satisfied!", allReferencesMatch);
	}

	@Test
	public void check_if_enum_singleton_is_thread_safe() throws InterruptedException {
		// Given
		NoteService referenceService = NoteServiceEnum.INSTANCE;
		
		int n = 100;
		ExecutorService executor = Executors.newFixedThreadPool(n);
		
		Callable<NoteService> getNoteServiceTask = () -> {
			return NoteServiceEnum.INSTANCE;
		};
		
		List<Future<NoteService>> results = new ArrayList<>();
		
		// When
		for (int i = 0; i < n; i++) {
			results.add(executor.submit(getNoteServiceTask));
		}
		
		// Then
		Thread.sleep(100);
		boolean allReferencesMatch = results.stream()
			.map(future -> {
				NoteService noteService = null;
				try {
					noteService = future.get();
				} catch (InterruptedException | ExecutionException e) {
					e.printStackTrace();
				}
				return noteService;
			})
			.allMatch(service -> {
				return service == referenceService;
			});
		
		Assert.assertTrue("One or more references is different! Singleton property has not been satisfied!", allReferencesMatch);
	}
	
	@Test
	public void check_if_enum_singleton_is_reflection_resistant() {
		NoteService service1 = NoteServiceEnum.INSTANCE;
		System.out.println("NoteServiceEnum instance: " + service1);
		
		NoteService service2 = null;
		
		try {
			System.out.println("Trying to instantiate another instance with Class.newInstance()");
			service2 = NoteServiceEnum.class.newInstance();
		} catch (InstantiationException | IllegalAccessException e) {
			System.out.println("Exception is " + e.getClass().getSimpleName());
		}
		
		System.out.println("\n--------------------------------------------------\n");
		
		Constructor<?> constructor = NoteServiceEnum.class.getDeclaredConstructors()[0];
		constructor.setAccessible(true);
		try {
			System.out.println("Trying to instantiate another instance with Constructor.newInstance()");
			service2 = (NoteService) constructor.newInstance();
		} catch (InstantiationException | IllegalAccessException | IllegalArgumentException | InvocationTargetException e) {
			System.out.println("Exception is " + e.getClass().getSimpleName());
			System.out.println("Message is: " + e.getMessage());
		}
		
		if (service2 != null) {
			Assert.assertEquals("Objects are not the same instance!", service1, service2);
		}
	}

	@Test
	public void check_if_class_singleton_is_reflection_resistant() throws ClassNotFoundException, InstantiationException,
			IllegalAccessException, IllegalArgumentException, InvocationTargetException, InterruptedException {
		
		NoteService service1 = NoteServiceClass.getInstance();
		System.out.println("NoteServiceClass instance #1: " + service1);

		Class<NoteServiceClass> clazz = NoteServiceClass.class;
		Constructor<?> constructor = clazz.getDeclaredConstructors()[0];
		constructor.setAccessible(true); // make private constructor accessible through reflection
		NoteService service2 = (NoteService) constructor.newInstance();
		System.out.println("NoteServiceClass instance #2:" + service2);

		System.out.println("HACK3D!");
		
		Assert.assertEquals("Objects are not the same instance!", service1, service2);
	}
	
	@Test
	public void check_removeLast_unsafe() {
		
		// Given
		NoteServiceEnum service = NoteServiceEnum.INSTANCE;
		int size = service.getNotes().size();
		ExecutorService executor = Executors.newFixedThreadPool(size);
		
		List<Callable<Void>> tasks = new ArrayList<>();
		for (int i = 0; i < size; i++) {
			tasks.add(() -> {
				System.out.println("Executing in thread: " + Thread.currentThread().getId());
				service.removeLastUnsafe();
				System.out.println();
				return null;
			});
		}
		
		// When
		for (Callable<Void> task : tasks) {
			executor.submit(task);
		}
		
		// Then
		Assert.assertTrue("List is not empty! It should be empty!", service.getNotes().isEmpty());
	}
	
	@Test
	public void check_removeLast_safe() throws InterruptedException {
		
		// Given
		NoteServiceEnum service = NoteServiceEnum.INSTANCE;
		int size = service.getNotes().size();
		ExecutorService executor = Executors.newFixedThreadPool(size);
		
		List<Callable<Void>> tasks = new ArrayList<>();
		for (int i = 0; i < size; i++) {
			tasks.add(() -> {
				System.out.println("Executing in thread: " + Thread.currentThread().getId());
				service.removeLastSafe();
				System.out.println();
				return null;
			});
		}
		
		// When
		for (Callable<Void> task : tasks) {
			executor.submit(task);
		}
		
		// we need to wait for tasks to complete
		Thread.sleep(10);
		
		// Then
		Assert.assertTrue("List is not empty! It should be empty!", service.getNotes().isEmpty());
	}
}
