import java.io.Serializable;

class Book extends LibraryItemPrototype implements Cloneable, Serializable {
  private String tag;
  private Author author;
  private String title;
  private int pages;
  private int year;

  public Book(String tag, Author author, String title, int pages, int year) {
    this.tag = tag;
    this.author = author;
    this.title = title;
    this.pages = pages;
    this.year = year;
  }

  public Book(Book book) {
    this(book.getTag(), new Author(book.getAuthor()), book.getTitle(), book.getPages(), book.getYear());
  }

  String getTag() { return this.tag; }
  void setTag(String tag) { this.tag = tag; }

  Author getAuthor() { return this.author; }
  void setAuthor(Author author) { this.author = author; }

  String getTitle() { return this.title; }
  void setTitle(String title) { this.title = title; }

  int getPages() { return this.pages; }
  void setPages(int pages) { this.pages = pages; }

  int getYear() { return this.year; }
  void setYear(int year) { this.year = year; }

  public String toString() {
    return this.author.toString() + ", \"" + this.title + "\", " + this.pages + ", " + this.year;
  }

  @Override
  public Object ShallowCopy() throws CloneNotSupportedException {
    System.out.println("[SHALLOW COPYING]: " + this.toString());
    return (LibraryItemPrototype) this.clone();
  }

  @Override
  public Object DeepCopy() throws CloneNotSupportedException {
    System.out.println("[DEEP COPYING]: " + this.toString());
    return (LibraryItemPrototype) new Book(this);
  }
}
