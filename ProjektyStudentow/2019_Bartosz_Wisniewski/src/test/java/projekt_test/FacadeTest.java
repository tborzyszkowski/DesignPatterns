package projekt_test;

import static org.junit.Assert.*;

import java.util.ArrayList;

import org.junit.Test;

import projekt.Book;
import projekt.FacadeASoIaF;
import projekt.Library;
import projekt.ServiceType;
import projekt.User;

public class FacadeTest {
	@Test
	public void facadeTest() throws InterruptedException {
	
		User user = new User.Builder().addName("Bartosz").addSurname("Wisniewski").addLibraryCardId("AZR-500").build();
		FacadeASoIaF fascade = new FacadeASoIaF();
		ArrayList<Book> bookList = FacadeASoIaF.addASoIaF();
		Library library = Library.getInstance(new ArrayList<Book>());
		library.addList(bookList);
		
		assertEquals(library.getBookList().get(0).getTitle(), "A Game of Thrones");
		assertEquals(library.getBookList().get(1).getTitle(), "A Clash of Kings");
		assertEquals(library.getBookList().get(2).getTitle(), "A Storm of Swords");
		assertEquals(library.getBookList().get(3).getTitle(), "A Feast for Crows");
		assertEquals(library.getBookList().get(4).getTitle(), "A Dance with Dragons");
		
		
		user = fascade.rentOrReturnASoIaF(user, ServiceType.RENT, library);
		assertEquals(user.getBookLimit(), 5);
		assertEquals(user.getBookList().get(0).getTitle(), "A Game of Thrones");
		assertEquals(user.getBookList().get(1).getTitle(), "A Clash of Kings");
		assertEquals(user.getBookList().get(2).getTitle(), "A Storm of Swords");
		assertEquals(user.getBookList().get(3).getTitle(), "A Feast for Crows");
		assertEquals(user.getBookList().get(4).getTitle(), "A Dance with Dragons");
		
		user = fascade.rentOrReturnASoIaF(user, ServiceType.RETURNED, library);
		assertEquals(user.getBookLimit(), 10);
		assertTrue(user.getBookList().isEmpty());
	}
}
