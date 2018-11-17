package com.mposluszny.dp.singleton;

import java.util.List;
import java.util.Optional;
import java.util.Random;

public class NoteServiceClass implements NoteService {
	
	private volatile static NoteService instance;
	
//	static {
//		instance = new NoteServiceClass();
//	}
	
	private NoteServiceClass() { } // private constructor enforces singleton property
	
	public static NoteService getInstance() throws InterruptedException {
		System.out.println("Thread " + Thread.currentThread().getId() + " instance is null: " + (instance == null));
		if (instance == null) {
//			synchronized (NoteServiceClass.class) {
				if (instance == null) {
	//				int waitTime = new Random().nextInt(50) + 10;
	//				System.out.println("Thread " + Thread.currentThread().getId() + " waiting for " + waitTime + "ms");
	//				Thread.sleep(waitTime);
					System.out.println("Thread " + Thread.currentThread().getId() + " creating new instance");
					instance = new NoteServiceClass();
				}
//			} 
		}
		return instance;
	}

	@Override
	public List<Note> getNotes() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Optional<Note> getNote(long id) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void addNote(Note note) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public boolean removeNote(Note note) {
		// TODO Auto-generated method stub
		return false;
	}
}
