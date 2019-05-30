abstract class Decorator extends LibraryItemPrototype {
  protected LibraryItemPrototype libraryItem;

  public Decorator(LibraryItemPrototype libraryItem) {
    this.libraryItem = libraryItem;
  }

  @Override
  public String toString() {
    return libraryItem.toString();
  }
}
