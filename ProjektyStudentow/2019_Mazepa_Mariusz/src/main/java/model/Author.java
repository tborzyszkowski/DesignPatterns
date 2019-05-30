import java.io.Serializable;

class Author extends Person implements Serializable {
  public Author(String firstName, String lastName) {
    super(firstName, lastName);
  }

  public Author(Author author) {
    super(author.getFirstName(), author.getLastName());
  }
}
