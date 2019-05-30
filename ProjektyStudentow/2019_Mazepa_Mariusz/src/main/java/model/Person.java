import java.io.Serializable;

class Person implements Serializable {
  private String firstName;
  private String lastName;

  public Person(String firstName, String lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
  }

  public Person(Person person) {
    this(person.getFirstName(), person.getLastName());
  }

  String getFirstName() {
    return this.firstName;
  }

  void setFirstName(String firstName) {
    this.firstName = firstName;
  }

  String getLastName() {
    return this.lastName;
  }

  void setLastName(String lastName) {
    this.lastName = lastName;
  }

  public String toString() {
    return this.lastName.toUpperCase() + " " + this.firstName;
  }
}
