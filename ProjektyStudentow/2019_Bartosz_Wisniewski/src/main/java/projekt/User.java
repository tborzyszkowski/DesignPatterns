package projekt;

import java.util.ArrayList;
import java.util.Iterator;





public class User {

	private String name;
	private String surname;
	private int bookLimit;
	ArrayList<Book> bookList;
	private String libraryCardId;
	
	public User(Builder builder) {
		name = builder.name;
		surname = builder.surname;
		bookLimit = builder.bookLimit;
		bookList = builder.bookList;
		libraryCardId = builder.libraryCardId;
	}

	public static class Builder {
		private String name;
		private String surname;
		private int bookLimit = 10;
		ArrayList<Book> bookList = new ArrayList<Book>();
		private String libraryCardId;
		
		public Builder addName(String name){
			this.name = name;
			return this;
		}
		public Builder addSurname(String surname){
			this.surname = surname;
			return this;
		}
		public Builder addBookLimit(int bookLimit){
			this.bookLimit = bookLimit;
			return this;
		}
		public Builder addBookList(ArrayList<Book> bookList){
			this.bookList = bookList;
			return this;
		}
		public Builder addLibraryCardId(String libraryCardId){
			this.libraryCardId = libraryCardId;
			return this;
		}
		public User build() {
			return new User(this);
		}
	}

	public String getName() {
		return this.name;
	}

	public String getSurname() {
		return this.surname;
	}

	public int getBookLimit() {
		return this.bookLimit;
	}
	public String getLibraryCardId() {
		return this.libraryCardId;
	}
	public ArrayList<Book> getBookList() {
		return this.bookList;
	}

	public void addBook(Book book) {
		bookList.add(book);
	}

	public void setBookLimit(int limit) {
		this.bookLimit = limit;
	}

	public void removeReturnedBook(String title) {
		Iterator<Book> i = bookList.iterator();
		RegularBook book;
		while (i.hasNext()) {
			book = (RegularBook) i.next();
			if (book.getTitle().equals(title)) {
				i.remove();
				break;
			}
		}
	}
}