package projekt;

public class ElaboratedBookDecorator extends BookDecorator {

	private Integer increasePeantlyBy;
	private String elaborator;

	public ElaboratedBookDecorator(Book decoratedBook, Integer increasePeantlyBy, String elaborator) {
		super(decoratedBook);
		this.increasePeantlyBy = increasePeantlyBy;
		this.elaborator = elaborator;
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
		return decoratedBook.getPenalty() + increasePeantlyBy;
	}

	public String getElaborator() {
		return elaborator;
	}

	public void setElaborator(String elaborator) {
		this.elaborator = elaborator;
	}

	public boolean setAvailable(boolean b) {
		return decoratedBook.setAvailable(b);
		
	}
}
