package projekt;

public interface Book {
	String getTitle();

	String getAuthor();

	String getISBN();

	Integer getReleaseYear();

	boolean isAvailable();

	Integer getPenalty();
	
	String getElaborator();

	boolean setAvailable(boolean b);
}
