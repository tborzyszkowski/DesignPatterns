package projekt_test;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

import projekt.RegularBook;
import projekt.Book;
import projekt.DamagedBookDecorator;
import projekt.ElaboratedBookDecorator;



public class BookTest {
	@Test
	public void createBookTest(){
		RegularBook book = new RegularBook("Metro 2033", "Glukhovsky", "9785171144258", 2005, true, 40);		
		assertEquals("Metro 2033", book.getTitle());
		assertEquals("Glukhovsky", book.getAuthor());
		assertEquals("9785171144258", book.getISBN());
		assertEquals(Integer.valueOf(2005), book.getReleaseYear());
		assertEquals(true, book.isAvailable());
		assertEquals(Integer.valueOf(40), book.getPenalty());
	}
	@Test
	public void createElaboratedBookTest(){
		RegularBook book = new RegularBook("Metro 2033", "Glukhovsky", "9785171144258", 2005, true, 40);
		Book elaboratedBook = new ElaboratedBookDecorator(book, 20, "Miodek");
		
		assertEquals("Metro 2033", elaboratedBook.getTitle());
		assertEquals("Glukhovsky", elaboratedBook.getAuthor());
		assertEquals("9785171144258", elaboratedBook.getISBN());
		assertEquals(Integer.valueOf(2005), elaboratedBook.getReleaseYear());
		assertEquals(true, elaboratedBook.isAvailable());
		assertEquals(Integer.valueOf(60), elaboratedBook.getPenalty());
		assertEquals("Miodek", elaboratedBook.getElaborator());
	}
	
	@Test
	public void createDamagedBookTest(){
		RegularBook book = new RegularBook("Metro 2033", "Glukhovsky", "9785171144258", 2005, true, 40);
		Book damagedBook = new DamagedBookDecorator(book, 20);
		
		assertEquals("Metro 2033", damagedBook.getTitle());
		assertEquals("Glukhovsky", damagedBook.getAuthor());
		assertEquals("9785171144258", damagedBook.getISBN());
		assertEquals(Integer.valueOf(2005), damagedBook.getReleaseYear());
		assertEquals(true, damagedBook.isAvailable());
		assertEquals(Integer.valueOf(20), damagedBook.getPenalty());
		
	}
	
}
