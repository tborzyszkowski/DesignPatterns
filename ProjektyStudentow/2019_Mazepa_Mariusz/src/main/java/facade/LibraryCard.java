class LibraryCard {
  public boolean hasLibraryCard(Borrower borrower) {
    System.out.println("   (!) Sprawdzanie, czy wypożyczający posiada kartę biblioteczną...");
    return borrower.getLibraryCard();
  }
}
