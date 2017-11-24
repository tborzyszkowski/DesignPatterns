/*
 * 166122 Tomasz Franckiewicz
 * FluentBuilder
 */
package FluentBuilder;

/*
 * Vehicle, the class with many parameters.
 */
public final class Vehicle {

  private final Type type;
  private final String name;
  private final Engine engineType;
  private final Frame frameType;
  private final Wheels wheels;
  private final Doors doors;

  private Vehicle(Builder builder) {
    this.type = builder.type;
    this.name = builder.name;
    this.frameType = builder.frameType;
    this.engineType = builder.engineType;
    this.wheels = builder.wheels;
    this.doors = builder.doors;
  }

  @Override
  public String toString() {

    StringBuilder sb = new StringBuilder();
    sb.append("This is a ").append(type).append(": ").append(name);
    sb.append(" with ").append(frameType);
    sb.append(" and Engine type: ").append(engineType);
    sb.append(" and with ").append(wheels).append(" wheels");    

    if (doors != null) {
      sb.append(" and with ").append(doors).append(" doors");
    }
    
    sb.append('.');
    return sb.toString();
  }

  /*
   * The builder class.
   */
  public static class Builder {

    private Type type;
    private String name;
    private Engine engineType;
    private Frame frameType;
    private Wheels wheels;
    private Doors doors;

    /*
     * Constructor
     */
    public Builder(Type type, String name) {
      this.type = type;
      this.name = name;
    }

    public Builder withEngineType(Engine engineType) {
      this.engineType = engineType;
      return this;
    }

    public Builder withFrameType(Frame frameType) {
      this.frameType = frameType;
      return this;
    }

    public Builder withWheels(Wheels wheels) {
      this.wheels = wheels;
      return this;
    }
    
    public Builder withDoors(Doors doors) {
      this.doors = doors;
      return this;
    }

    public Vehicle build() {
      return new Vehicle(this);
    }
  }
}
