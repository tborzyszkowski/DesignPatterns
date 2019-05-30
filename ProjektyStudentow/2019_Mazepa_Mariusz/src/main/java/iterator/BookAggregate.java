import java.util.ArrayList;

class BookAggregate extends Aggregate {
  private ArrayList<Book> books = new ArrayList<Book>();

  public Iterator CreateIterator() {
    return new BookIterator(this);
  };

  public int Count() {
    return books.size();
  }

  public Object get(int index) {
    return this.books.get(index);
  }

  public Object getBooks() {
    return this.books;
  }

  public void setBooks(ArrayList<Book> books) {
    this.books = books;
  }
}
