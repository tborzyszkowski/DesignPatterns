/*
 * 166122 Tomasz Franckiewicz
 * FluentBuilder
 */
package FluentBuilder;

public enum Frame {

  CAR("Car Frame"), MOTORCYCLE("Motorcycle Frame"), SCOOTER("Scooter Frame");
  
  private String title;

  Frame(String title) {
    this.title = title;
  }

  @Override
  public String toString() {
    return title;
  }

}
