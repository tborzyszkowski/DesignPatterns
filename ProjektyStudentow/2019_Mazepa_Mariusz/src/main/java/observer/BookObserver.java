class BookObserver extends Observer {
  public BookObserver(String firstName, String lastName) {
    super(firstName, lastName);
  }

  public void Update(Borrowable book) {
    System.out.println("\nINFORMACJA DLA: " + this);
    System.out.print("   " + book);
    System.out.println("   Dostępnych egzemplarzy: " + book.getCopies());
  }
}
