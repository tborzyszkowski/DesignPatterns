class Person {
  private String firstName;
  private String lastName;

  public Person(String firstName, String lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
  }

  public Person(Person author) {
    this(author.getFirstName(), author.getLastName());
  }

  String getFirstName() {
    return this.firstName;
  }

  void setFirstName(String firstName) {
    System.out.println("=> Zmieniam imię z \"" + this.firstName + "\" na \"" + firstName + "\".");
    this.firstName = firstName;
  }

  String getLastName() {
    return this.lastName;
  }

  void setLastName(String lastName) {
    System.out.println("=> Zmieniam nazwisko z \"" + this.lastName + "\" na \"" + lastName + "\".");
    this.lastName = lastName;
  }

  public String toString() {
    return this.firstName + " " + this.lastName;
  }
}
