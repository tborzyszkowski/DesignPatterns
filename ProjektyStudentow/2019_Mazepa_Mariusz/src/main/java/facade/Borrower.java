class Borrower extends Person {
  private boolean libraryCard;

  public Borrower(String firstName, String lastName) {
    super(firstName, lastName);
  }

  public Borrower(Borrower borrower) {
    super(borrower.getFirstName(), borrower.getLastName());
  }

  boolean getLibraryCard() {
    return this.libraryCard;
  }

  void setLibraryCard(boolean libraryCard) {
    this.libraryCard = libraryCard;
  }
}
