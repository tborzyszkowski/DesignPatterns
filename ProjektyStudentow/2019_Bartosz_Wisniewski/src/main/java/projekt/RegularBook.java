package projekt;

public class RegularBook implements Book {

	private String title;
	private String author;
	private String ISBN;
	private Integer releaseYear;
	private boolean available;
	private Integer penalty;

	
	public RegularBook(String title, String author, String iSBN, Integer releaseYear, boolean available,
			Integer penalty) {
		this.title = title;
		this.author = author;
		this.ISBN = iSBN;
		this.releaseYear = releaseYear;
		this.available = available;
		this.penalty = penalty;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getAuthor() {
		return author;
	}

	public void setAuthor(String author) {
		this.author = author;
	}

	public String getISBN() {
		return ISBN;
	}

	public void setISBN(String iSBN) {
		ISBN = iSBN;
	}

	public Integer getReleaseYear() {
		return releaseYear;
	}

	public void setReleaseYear(Integer releaseYear) {
		this.releaseYear = releaseYear;
	}

	public boolean isAvailable() {
		return available;
	}

	public boolean setAvailable(boolean available) {
		return this.available = available;
	}

	public Integer getPenalty() {
		return penalty;
	}

	public void setPenalty(Integer penalty) {
		this.penalty = penalty;
	}

	public String getElaborator() {
		// TODO Auto-generated method stub
		return null;
	}
	
}
