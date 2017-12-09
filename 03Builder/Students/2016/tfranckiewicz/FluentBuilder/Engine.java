/*
 * 166122 Tomasz Franckiewicz
 * FluentBuilder
 */
package FluentBuilder;

public enum Engine {

  SMALL("50 cc"), MEDIUM("500 cc"), BIG("2500 cc");

  private String title;

  Engine(String title) {
    this.title = title;
  }

  @Override
  public String toString() {
    return title;
  }
}
