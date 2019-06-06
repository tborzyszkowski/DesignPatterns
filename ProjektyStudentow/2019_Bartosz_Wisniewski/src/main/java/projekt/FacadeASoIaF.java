package projekt;

import java.util.ArrayList;

public class FacadeASoIaF {

	public User rentOrReturnASoIaF(User user, ServiceType serviceType, Library library) throws InterruptedException {
		user = library.serviceBook(user, "A Game of Thrones", serviceType);
		user = library.serviceBook(user, "A Clash of Kings", serviceType);
		user = library.serviceBook(user, "A Storm of Swords", serviceType);
		user = library.serviceBook(user, "A Feast for Crows", serviceType);
		user = library.serviceBook(user, "A Dance with Dragons", serviceType);
		return user;
	}

	public static ArrayList<Book> addASoIaF() {
		ArrayList<Book> bookList = new ArrayList<Book>();
		RegularBook asoiafTomeOne = new RegularBook("A Game of Thrones", "Martin", "0-553-10354-7", 1996, true, 97);
		RegularBook asoiafTomeTwo = new RegularBook("A Clash of Kings", "Martin", "0-553-10803-4", 1999, true, 92);
		RegularBook asoiafTomeThree = new RegularBook("A Storm of Swords", "Martin", "0-553-10663-5", 2000, true, 57);
		RegularBook asoiafTomeFour = new RegularBook("A Feast for Crows", "Martin", "0-553-80150-3", 2005, true, 54);
		RegularBook asoiafTomeFive = new RegularBook("A Dance with Dragons", "Martin", "978-0553801477-7", 2011, true, 63);
		
	
	

		bookList.add(asoiafTomeOne);
		bookList.add(asoiafTomeTwo);
		bookList.add(asoiafTomeThree);
		bookList.add(asoiafTomeFour);
		bookList.add(asoiafTomeFive);
		return bookList;
	}

}