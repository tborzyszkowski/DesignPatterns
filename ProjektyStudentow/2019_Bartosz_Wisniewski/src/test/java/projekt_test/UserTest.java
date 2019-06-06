package projekt_test;

import static org.junit.Assert.*;

import org.junit.Test;

import projekt.RegularBook;
import projekt.User;

public class UserTest {

	
	
	@Test
	public void createUserTest() {
		User user = new User.Builder().addName("Bartosz").addSurname("Wisniewski").addLibraryCardId("AZR-500").build();
		assertEquals(user.getName(), "Bartosz");
		assertEquals(user.getSurname(), "Wisniewski");
		assertEquals(user.getBookLimit(), 10);
		assertEquals(user.getBookList().size(), 0);	
	}
	@Test
	public void addBookTest(){
		User user = new User.Builder().addName("Bartosz").addSurname("Wisniewski").addLibraryCardId("AZR-500").build();
		RegularBook book = new RegularBook("Metro 2033", "Glukhovsky", "9785171144258", 2005, true, 40);
		user.addBook(book);
		assertEquals(user.getBookList().size(), 1);
		assertTrue(user.getBookList().contains(book));
	}
	@Test
	public void removeBookTest(){
		User user = new User.Builder().addName("Bartosz").addSurname("Wisniewski").addLibraryCardId("AZR-500").build();
		RegularBook book = new RegularBook("Metro 2033", "Glukhovsky", "9785171144258", 2005, true, 40);
		user.addBook(book);
		user.removeReturnedBook("Metro 2033");
		assertEquals(user.getBookList().size(), 0);	
		assertFalse(user.getBookList().contains(book));
	}
}
