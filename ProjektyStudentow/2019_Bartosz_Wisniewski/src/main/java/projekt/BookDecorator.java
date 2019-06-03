package projekt;

abstract class BookDecorator implements Book{

	protected Book decoratedBook;
	
	public BookDecorator(Book decoratedBook){
		this.decoratedBook = decoratedBook;
	}

}
