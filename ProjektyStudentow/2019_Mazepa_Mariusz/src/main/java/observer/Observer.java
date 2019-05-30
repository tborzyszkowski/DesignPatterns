abstract class Observer extends Person {
  public Observer(String firstName, String lastName) {
    super(firstName, lastName);
  }

  public abstract void Update(Borrowable book);
}
