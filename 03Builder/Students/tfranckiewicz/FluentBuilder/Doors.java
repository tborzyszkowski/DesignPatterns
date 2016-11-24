/*
 * 166122 Tomasz Franckiewicz
 * FluentBuilder
 */
package FluentBuilder;

public enum Doors {

  FOUR;

  @Override
  public String toString() {
    return name().toLowerCase();
  }
}
