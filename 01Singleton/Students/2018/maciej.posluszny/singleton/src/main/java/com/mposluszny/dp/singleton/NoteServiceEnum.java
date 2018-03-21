package com.mposluszny.dp.singleton;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

/**
 * W tym podejściu mamy gwarancję, że konstrukcja obiektu jest thread-safe.
 * Należy pamiętać, że metody instancji już nie są thread-safe i mogą potrzebować synchronizacji lub transakcyjności.
 * Warto zwrócić uwagę na to, że nie da się w żaden sposób otrzymać kopii obiektu, nawet przez refleksję.
 */
public enum NoteServiceEnum implements NoteService {

	INSTANCE;
	
//	static {
//		System.out.println("Static init!");
//	}
	
//	INSTANCE(SomeInitData data);
	
//	private NoteServiceEnum(SomeInitData data) {
//		this.data = data;
//	}
	
	private List<Note> notes = new ArrayList<>();
	
	public void init(List<Note> notes) {
		this.notes = notes;
	}

	@Override
	public List<Note> getNotes() {
		return notes;
	}

	@Override
	public Optional<Note> getNote(long id) {
		return notes.stream()
				.filter(note -> {
					return note.getId() == id;
				})
				.findFirst();
	}

	@Override
	public void addNote(Note note) {
		notes.add(note);
	}

	@Override
	public boolean removeNote(Note note) {
		return notes.remove(note);
	}
	
	public void removeLastUnsafe() {
		int size = notes.size();
		System.out.println("List size is: " + size);
		notes.remove(size-1);
		System.out.println(String.format("notes[%d] removed", size -1));
	}
	
	public synchronized void removeLastSafe() {
		// gdyby size bylo polem tej instancji to moglibysmy je oznaczyc jako volatile 
		int size = notes.size();
		System.out.println("List size is: " + size);
		notes.remove(size - 1);
		System.out.println(String.format("notes[%d] removed", size - 1));
	}
	
//	public void removeLastSafe() {
//		synchronized (INSTANCE) {
//			int size = notes.size();
//			System.out.println("List size is: " + size);
//			notes.remove(size - 1);
//			System.out.println(String.format("notes[%d] removed", size - 1));
//		}
//	}
}
