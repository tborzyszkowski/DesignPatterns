package com.mposluszny.dp.singleton;

import java.util.List;
import java.util.Optional;

public interface NoteService {

	public List<Note> getNotes();
	public Optional<Note> getNote(long id);
	public void addNote(Note note);
	public boolean removeNote(Note note);
}
