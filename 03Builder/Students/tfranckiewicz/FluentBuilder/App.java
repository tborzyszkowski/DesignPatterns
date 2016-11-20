/*
 * 166122 Tomasz Franckiewicz
 * FluentBuilder
 */
package FluentBuilder;

public class App {

  public static void main(String[] args) {

    Vehicle car = 
      new Vehicle.Builder(Type.CAR, "Ford")
    	  .withFrameType(Frame.CAR)
    	  .withEngineType(Engine.BIG)
    	  .withWheels(Wheels.FOUR)
    	  .withDoors(Doors.FOUR).build();

    Vehicle motorcycle =
      new Vehicle.Builder(Type.MOTORCYCLE, "Suzuki")
    	  .withFrameType(Frame.MOTORCYCLE)
          .withEngineType(Engine.MEDIUM)
          .withWheels(Wheels.TWO)
          .build();

    Vehicle scooter =
      new Vehicle.Builder(Type.SCOOTER, "Vespa")
          .withFrameType(Frame.SCOOTER)
          .withEngineType(Engine.SMALL)
          .withWheels(Wheels.TWO).build();
        
    System.out.println(car);
    System.out.println(motorcycle);    
    System.out.println(scooter);

  }
}
