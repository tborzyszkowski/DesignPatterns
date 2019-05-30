class BorrowFacade {
  private LibraryCard libraryCard;

  public BorrowFacade() {
    libraryCard = new LibraryCard();
  }

  public String borrowItem(Borrowable book, Borrower borrower) {
    if (libraryCard.hasLibraryCard(borrower)) {
      if (book.getCopies() > 0) {
        book.borrowItem(borrower);
        return "Książka wypożyczona!";
      } else {
        return "Książka niedostępna do wypożyczenia!";
      }
    } else {
      return "Wypożyczający nie posiada karty bibliotecznej!";
    }
  }

  public String returnItem(Borrowable book, Borrower borrower) {
    if (libraryCard.hasLibraryCard(borrower)) {
      book.returnItem(borrower);
      return "Książka oddana!";
    } else {
      return "Wypożyczający nie posiada karty bibliotecznej!";
    }
  }
}
