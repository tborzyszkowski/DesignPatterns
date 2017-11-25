/*
 * 166122 Tomasz Franckiewicz
 * FluentBuilder
 */
package FluentBuilder;

public enum Type {

  CAR, SCOOTER, MOTORCYCLE;

  @Override
  public String toString() {
    return name().toLowerCase();
  }
}
