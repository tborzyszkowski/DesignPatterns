abstract class LibraryItemPrototype {
  public int copies;

  int getCopies() {
    return this.copies;
  }

  void setCopies(int copies) {
    this.copies = copies;
  }

  public abstract String toString();

  public abstract Object ShallowCopy() throws CloneNotSupportedException;
  public abstract Object DeepCopy() throws CloneNotSupportedException;
}
