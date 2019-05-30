import java.io.Serializable;
import java.io.FileNotFoundException;
import java.io.IOException;

import java.util.ArrayList;

class Library implements Serializable {
  private static Library instance;

  private static String tag;
  private static String name;
  private static ArrayList<Book> books;

  private Library() {
    System.out.println("Library():     Inicjalizowanie instacji.");
  }

	public static Library getInstance() {
		if (instance == null) {
			synchronized(Library.class) {
				if (instance == null) {
					System.out.println("getInstance(): Pierwsze wywołanie.");
					instance = new Library();
				}
			}
		}
		return instance;
	}

  String getTag() { return this.tag; }
  void setTag(String tag) { this.tag = tag; }

  String getName() { return this.name; }
  void setName(String name) { this.name = name; }

  ArrayList<Book> getBooks() { return this.books; }
  void setBooks(ArrayList<Book> books) { this.books = books; }

  public ArrayList<Book> prepareClonedBooks(Library library) throws CloneNotSupportedException {
    ArrayList<Book> books = new ArrayList<Book>();
    for (Book book : library.getBooks()) {
      books.add((Book) book.DeepCopy());
    }
    return books;
  }

  public String toString() {
    String generalInfo = "\n   Biblioteka \"" + this.name + "\"\n";
    int booksCounter = 1;
    generalInfo += "      LISTA KSIĄŻEK:";
    for (Book book : books) {
      generalInfo += "\n         " + (booksCounter++) + ". " + book.toString();
    }
    return generalInfo;
  }

  protected Object readResolve() throws FileNotFoundException, IOException, ClassNotFoundException {
    System.out.println("\nFromFile: " + this.hashCode());
    if (instance == null) {
      System.out.println("Instance:      " + null + "\n");
      System.out.println("readResolve(): Instancja nie istnieje, biorę z pliku.");
    } else {
      System.out.println("Instance: " + instance.hashCode() + "\n");
      System.out.println("readResolve(): Instancja istnieje, podmieniam z pliku.");
    }
    instance = this;
    return instance;
  }
}
