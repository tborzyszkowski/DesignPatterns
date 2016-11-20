/*
 * 166122 Tomasz Franckiewicz
 * FluentBuilder
 */
package FluentBuilder;

public enum Wheels {

  FOUR, TWO;

  @Override
  public String toString() {
    return name().toLowerCase();
  }
}
