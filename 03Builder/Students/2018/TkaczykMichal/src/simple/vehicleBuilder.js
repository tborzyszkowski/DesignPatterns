const classes = require('../classes');

class Builder {
  constructor() {
    this.buildType = () => {
    }

    this.buildColor = () => {
    }

    this.buildEngine = () => {
    }
  }
}

class ConcreteBuilder extends Builder {
  constructor() {
    super();
    this.vehicle = '';

    this.construct = (type) => {
      switch(type) {
        case 'car':
          this.vehicle = new classes.Car();
          console.log(this.vehicle);
          break;
        case 'plane':
          this.vehicle = new classes.Plane();
          break;
      }

      return this;
    }

    this.buildType = (type) => {
      this.vehicle.setType(type);
      return this;
    }

    this.buildColor = (color) => {
      this.vehicle.setColor(color);
      return this;
    }

    this.buildEngine = (engine) => {
      this.vehicle.setEngine(engine);
      return this;
    }

    this.getVehicle = () => {
      return this.vehicle;
    }
  }
}

class Director {
  constructor() {
    this.builder = new ConcreteBuilder();

    this.construct = (type, color, engine) => {
      this.builder
      .construct(type)
      .buildColor(color)
      .buildEngine(engine);
    }

    this.getResult = () => {
      return this.builder.getVehicle();
    }
  }
}

const director = new Director();
director.construct('plane', 'blue', 'turbo super');

const newPlane = director.getResult();


console.log(newPlane);

/* 
  Zad 2

  Lepszym (pod względem komplikacji kodu) rozwiązaniem będzie:
    1. Budowniczy w przypadku, gdy nie chcemy tworzyc calego obiektu w jednej chwili,
    a potrzebujemy tylko kilku metod, ktore utworza nam podstawowe pola potrzebne 
    do standardowego działania obiektu, a pozniej bedziemy mogli utworzyc dodatkowe pola
    za pomoca istniejacych metod

    2. Fabryka abstrakcyjna w przypadku, gdy do utworzenia mamy więcej prostszych obiektow
    bez duzego zaglebienia i wymagajacych wypelnienia wszystkich pol do poprawnego dzialania

*/