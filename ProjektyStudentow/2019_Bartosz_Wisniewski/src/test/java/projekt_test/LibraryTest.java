package projekt_test;

import static org.junit.Assert.*;

import java.util.ArrayList;

import org.junit.Test;

import projekt.RegularBook;
import projekt.Book;
import projekt.ElaboratedBookDecorator;
import projekt.Library;
import projekt.ServiceType;
import projekt.User;

public class LibraryTest {
	@Test
	public void rentThenReturnBookTest() throws InterruptedException {
		User user = new User.Builder().addName("Bartosz").addSurname("Wisniewski").addLibraryCardId("AZR-500").build();
		Book book = new RegularBook("Metro 2033", "Glukhovsky", "9785171144258", 2005, true, 40);
		Book book2 = new RegularBook("Witajcie w Rosji", "Glukhovsky", "9788363944469", 2005, true, 40);
		Book book3 = new ElaboratedBookDecorator(book2, 20, "Miodek");
		ArrayList<Book> bookList = new ArrayList<Book>();
		bookList.add(book);
		bookList.add(book2);
		bookList.add(book3);

		Library library = Library.getInstance(new ArrayList<Book>());
		library.addList(bookList);
		
		user = library.serviceBook(user, book.getTitle(), ServiceType.RENT);
		assertEquals(user.getBookLimit(), 9);
		assertEquals(user.getBookList().get(0).getTitle(), "Metro 2033");
		assertFalse(book.isAvailable());
		
		
		user = library.serviceBook(user, book.getTitle(), ServiceType.RETURNED);
		assertEquals(user.getBookLimit(), 10);
		assertTrue(user.getBookList().isEmpty());
		assertTrue(book.isAvailable());
		
		user = library.serviceBook(user, book3.getTitle(), ServiceType.RENT);
		assertEquals(user.getBookLimit(), 9);
		assertEquals(user.getBookList().get(0).getTitle(), "Witajcie w Rosji");
		assertFalse(book3.isAvailable());
		
		
		user = library.serviceBook(user, book3.getTitle(), ServiceType.RETURNED);
		assertEquals(user.getBookLimit(), 10);
		assertTrue(user.getBookList().isEmpty());
		assertTrue(book3.isAvailable());
		
	}
}
