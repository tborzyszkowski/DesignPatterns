import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.File;

import java.util.ArrayList;

import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;

public class LibraryTest {
  static String filename = "instance.ser";

  static Author author1;
  static Author author2;
  static Author author3;

  static String tag1 = "beedle";
  static String tag2 = "jezioro";
  static String tag3 = "dreamcatcher";

  static Book book1;
  static Book book2;
  static Book book3;

  static String libraryTag = "gdansk_library";
  static String libraryName = "CzytaMY, bo lubiMY!";
  static Library library;

  static DisplayManager dm = new DisplayManager();
  static LibraryManager lm = new LibraryManager();
  static BookManager bm = new BookManager();

  @BeforeClass
  public static void setUpClass() throws FileNotFoundException, IOException, ClassNotFoundException {
    dm.mainHeader();
    System.out.println("Rozpoczęcie testowania...");

    lm.serialize(Library.getInstance(), filename);
  }

  @AfterClass
  public static void tearDownClass() {
    dm.horizontalLine(55);
    new File(filename).delete();
    System.out.println("Testowanie zakończone.");
    System.out.print("\n");
  }

  @Before
  public void setUp() {
    dm.horizontalLine(55);

    author1 = new Author("Joanne Kathleen", "Rowling");
    author2 = new Author("Krystyna", "Siesicka");
    author3 = new Author("Stephen", "King");

    book1 = new Book(tag1, author1, "Baśnie Barda Beedle'a", 144, 2008);
    book2 = new Book(tag2, author2, "Jezioro osobliwości", 160, 1999);
    book3 = new Book(tag3, author3, "Łowca snów", 768, 2001);

    bm.setBook(tag1, book1);
    bm.setBook(tag2, book2);
    bm.setBook(tag3, book3);

    ArrayList<Book> books = new ArrayList<Book>();
    books.add(book1);
    books.add(book2);
    books.add(book3);
  }

  @After
  public void tearDown() {
    lm.resetSingleton(Library.class, "instance");
  }

  @Test
  public void librarySingletonTest() {
    dm.testHeader("Library Singleton Test");

    Library instance1 = Library.getInstance();
    Library instance2 = Library.getInstance();

    assertThat(instance2.hashCode(), equalTo(instance1.hashCode()));
    lm.displayHashCodes(instance1, instance2);
  }

  @Test
  public void serializationWithInstanceTest() throws FileNotFoundException, IOException, ClassNotFoundException {
    dm.testHeader("Serialization WITH Instance Test");

    Library instance1 = Library.getInstance();
    Library instance2;
    Library instance3;

    lm.serialize(instance1, filename);
    instance2 = lm.deserialize(filename);

    assertThat(instance2, instanceOf(Library.class));
    assertThat(instance2.hashCode(), not(equalTo(instance1.hashCode())));
    assertNotSame(instance2, instance1);

    instance3 = Library.getInstance();
    assertThat(instance3, instanceOf(Library.class));
    assertThat(instance3.hashCode(), equalTo(instance2.hashCode()));
    assertSame(instance3, instance2);

    lm.displayHashCodes(instance1, instance2, instance3);
  }

  @Test
  public void serializationWithoutInstanceTest() throws FileNotFoundException, IOException, ClassNotFoundException {
    dm.testHeader("Serialization WITHOUT Instance Test");

    Library instance1 = lm.deserialize(filename);
    Library instance2 = Library.getInstance();

    assertThat(instance1, instanceOf(Library.class));
    assertThat(instance1.hashCode(), equalTo(instance2.hashCode()));
    assertSame(instance1, instance2);
    lm.displayHashCodes(instance1, instance2);
  }

  @Test
  public void book_shallowCopyTest() throws CloneNotSupportedException {
    dm.testHeader("(Book) Shallow Copy Test");

    Book book1_shallowCopy = (Book) bm.getBook(book1.getTag()).ShallowCopy();
    book1.getAuthor().setFirstName("Jadwiga");
    bm.displayBoth("Shallow", book1, book1_shallowCopy);
    assertEquals(book1.getAuthor(), book1_shallowCopy.getAuthor());
    assertSame(book1.getAuthor(), book1_shallowCopy.getAuthor());

    Book book2_shallowCopy = (Book) bm.getBook(book2.getTag()).ShallowCopy();
    book2.getAuthor().setLastName("Zmiana");
    bm.displayBoth("Shallow", book2, book2_shallowCopy);
    assertEquals(book2.getAuthor(), book2_shallowCopy.getAuthor());
    assertSame(book2.getAuthor(), book2_shallowCopy.getAuthor());

    Book book3_shallowCopy = (Book) bm.getBook(book3.getTag()).ShallowCopy();
    book3.getAuthor().setFirstName("Stefan");
    book3.getAuthor().setLastName("Król");
    bm.displayBoth("Shallow", book3, book3_shallowCopy);
    assertEquals(book3.getAuthor(), book3_shallowCopy.getAuthor());
    assertSame(book3.getAuthor(), book3_shallowCopy.getAuthor());
  }

  @Test
  public void book_deepCopyTest() throws CloneNotSupportedException {
    dm.testHeader("(Book) Deep Copy Test");

    Book book1_deepCopy = (Book) bm.getBook(book1.getTag()).DeepCopy();
    book1.getAuthor().setFirstName("Jadwiga");
    bm.displayBoth("Deep", book1, book1_deepCopy);
    assertNotEquals(book1.getAuthor(), book1_deepCopy.getAuthor());
    assertNotSame(book1.getAuthor(), book1_deepCopy.getAuthor());

    Book book2_deepCopy = (Book) bm.getBook(book2.getTag()).DeepCopy();
    book2.getAuthor().setLastName("Zmiana");
    bm.displayBoth("Deep", book2, book2_deepCopy);
    assertNotEquals(book2.getAuthor(), book2_deepCopy.getAuthor());
    assertNotSame(book2.getAuthor(), book2_deepCopy.getAuthor());

    Book book3_deepCopy = (Book) bm.getBook(book3.getTag()).DeepCopy();
    book3.getAuthor().setFirstName("Stefan");
    book3.getAuthor().setLastName("Król");
    bm.displayBoth("Deep", book3, book3_deepCopy);
    assertNotEquals(book3.getAuthor(), book3_deepCopy.getAuthor());
    assertNotSame(book3.getAuthor(), book3_deepCopy.getAuthor());
  }

  @Test
  public void decoratorTest() {
    dm.testHeader("(Borrowable) Decorator Test");

    Borrower borrower1 = new Borrower("Stanisław", "Książka");
    Borrower borrower2 = new Borrower("Gertruda", "Myśliciel");

    LibraryItemPrototype book = bm.getBook(book1.getTag());
    book.setCopies(2);
    Borrowable borrowBook = new Borrowable(book);
    assertEquals(2, book.getCopies());

    System.out.println("Dostępne egzemplarze: " + book.getCopies());
    System.out.print("\n");
    System.out.println(borrowBook);
    borrowBook.borrowItem(borrower1);
    assertEquals(1, book.getCopies());

    System.out.println("Dostępne egzemplarze: " + book.getCopies());
    System.out.print("\n");
    System.out.println(borrowBook);
    borrowBook.borrowItem(borrower2);
    assertEquals(0, book.getCopies());

    System.out.println("Dostępne egzemplarze: " + book.getCopies());
    System.out.print("\n");
    System.out.println(borrowBook);
    borrowBook.returnItem(borrower1);
    assertEquals(1, book.getCopies());

    System.out.println("Dostępne egzemplarze: " + book.getCopies());
    System.out.print("\n");
    System.out.println(borrowBook);
  }

  @Test
  public void facadeTest() {
    dm.testHeader("Facade Test");

    Borrower borrower = new Borrower("Stanisław", "Książka");
    borrower.setLibraryCard(true);

    Borrowable bookToBorrow = new Borrowable(book1);
    bookToBorrow.setCopies(1);

    BorrowFacade facade = new BorrowFacade();

    System.out.println("POSIADACZ KARTY:");
    String borrowing = facade.borrowItem(bookToBorrow, borrower);
    System.out.println("   Wypożyczam: " + borrowing);
    assertEquals(1, bookToBorrow.borrowers.size());
    String returning = facade.returnItem(bookToBorrow, borrower);
    System.out.println("   Oddaję:     " + returning);
    assertEquals(0, bookToBorrow.borrowers.size());

    borrower.setLibraryCard(false);

    System.out.println("GOŚĆ BEZ KARTY:");
    borrowing = facade.borrowItem(bookToBorrow, borrower);
    System.out.println("   Wypożyczam: " + borrowing);
    assertEquals(0, bookToBorrow.borrowers.size());
  }

  @Test
  public void iteratorTest() {
    dm.testHeader("Iterator Test");

    BookAggregate ba = new BookAggregate();
    ArrayList<Book> books = new ArrayList<Book>();
    books.add(book1);
    books.add(book2);
    books.add(book3);
    ba.setBooks(books);

    Iterator iterator = ba.CreateIterator();

    System.out.println("Przeglądanie katalogu książek...");

    Object book = iterator.First();
    while (book != null) {
      System.out.println("   " + book);
      assertNotNull(book);
      if (iterator.HasNext())
        book = iterator.Next();
      else
        break;
    }
  }

  @Test
  public void observatorTest() {
    dm.testHeader("Observer Test");

    Observer observer1 = new BookObserver("Janusz", "Kowalski");
    Observer observer2 = new BookObserver("Ryszard", "Nowak");
    Observer observer3 = new BookObserver("Zygmunt", "Malinowski");

    Borrowable book = new Borrowable(book1);
    book.Attach(observer1);
    book.Attach(observer2);
    book.Attach(observer3);

    assertEquals(3, book.observers.size());

    for (int i = 0; i < 3; i++) {
      System.out.println("\n----- [ZMIENIŁA SIĘ ILOŚĆ DOSTĘPNYCH EGZEMPLARZY] -----");
      book.setCopies(i+1);
    }
  }
}
