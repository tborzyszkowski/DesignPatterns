package projekt;

import java.util.ArrayList;

public class Library {

	private static Library instance;
	private boolean Flag = false;
	private ArrayList<Book> bookList;

	private Library(ArrayList<Book> bookList) {
		this.bookList = bookList;
	}

	public static Library getInstance(ArrayList<Book> bookList) {
		synchronized (Library.class) {
			if (instance == null) {
				instance = new Library(bookList);
			}
		}
		return instance;
	}

	public void addList(ArrayList<Book> bookList) {
		this.bookList.addAll(bookList);
	}

	public synchronized User serviceBook(User user, String title, ServiceType serviceType) throws InterruptedException {
		while (Flag == true) {
			wait();
		}
		Flag = true;
		switch (serviceType) {
		case RENT:
			if (user.getBookLimit() > 0) {
				for (Book book : bookList) {
					if (book.getTitle().equals(title) && book.isAvailable()) {
						user.addBook(book);
						book.setAvailable(false);
						user.setBookLimit(user.getBookLimit() - 1);
						break;
					}
				}
			}
			break;
		case RETURNED:
			for (Book book : bookList) {
				if (book.getTitle().equals(title) && !book.isAvailable()) {
					book.setAvailable(true);
					user.removeReturnedBook(title);
					user.setBookLimit(user.getBookLimit() + 1);
					break;
				}
			}
			break;
		}
		Flag = false;
		return user;
	}

	public ArrayList<Book> getBookList() {
		return bookList;
	}
}
