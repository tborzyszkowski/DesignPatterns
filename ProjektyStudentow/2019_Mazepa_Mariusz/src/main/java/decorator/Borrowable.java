import java.util.ArrayList;

class Borrowable extends Decorator {
  protected ArrayList<Borrower> borrowers = new ArrayList<Borrower>();
  protected ArrayList<Observer> observers = new ArrayList<Observer>();

  public Borrowable(LibraryItemPrototype libraryItem) {
    super(libraryItem);
  }

  public void borrowItem(Borrower borrower) {
    borrowers.add(borrower);
    libraryItem.setCopies(libraryItem.getCopies() - 1);
  }

  public void returnItem(Borrower borrower) {
    borrowers.remove(borrower);
    libraryItem.setCopies(libraryItem.getCopies() + 1);
  }

  public void Attach(Observer observer) {
    observers.add(observer);
  }

  public void Detach(Observer observer) {
    observers.remove(observer);
  }

  public void Notify() {
    for (Observer observer : observers) {
      observer.Update(this);
    }
  }

  @Override
  void setCopies(int copies) {
    this.copies = copies;
    Notify();
  }

  @Override
  public String toString() {
    String decoratorString = super.toString() + "\n";
    for (Borrower borrower : borrowers)
      decoratorString += "   Wypożyczone przez: " + borrower + "\n";
    return decoratorString;
  }

  @Override
  public Object ShallowCopy() throws CloneNotSupportedException {
    System.out.println("[SHALLOW COPYING]: " + this.toString());
    return (LibraryItemPrototype) this.clone();
  }

  @Override
  public Object DeepCopy() throws CloneNotSupportedException {
    System.out.println("[DEEP COPYING]: " + this.toString());
    return (LibraryItemPrototype) new Borrowable(this);
  }
}
