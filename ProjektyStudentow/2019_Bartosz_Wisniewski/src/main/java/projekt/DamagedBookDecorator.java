package projekt;

public class DamagedBookDecorator extends BookDecorator {

	private Integer decreasePeantlyBy;

	public DamagedBookDecorator(Book decoratedBook, Integer decreasePeantlyBy) {
		super(decoratedBook);
		this.decreasePeantlyBy = decreasePeantlyBy;
	
	}

	public String getTitle() {
		return decoratedBook.getTitle();
	}

	public String getAuthor() {
		return decoratedBook.getAuthor();
	}

	public String getISBN() {
		return decoratedBook.getISBN();
	}

	public Integer getReleaseYear() {
		return decoratedBook.getReleaseYear();
	}

	public boolean isAvailable() {
		return decoratedBook.isAvailable();
	}

	public Integer getPenalty() {
		return decoratedBook.getPenalty() - decreasePeantlyBy;
	}

	public boolean setAvailable(boolean b) {
		return decoratedBook.setAvailable(b);

	}

	public String getElaborator() {
		// TODO Auto-generated method stub
		return null;
	}
}