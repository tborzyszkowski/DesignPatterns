class Vehicle {
  constructor() {
    this.type = "";
    this.color = "";
    this.engine = "";
  }

  setType(type) {
    this.type = type;
  }

  setColor(color) {
    this.color = color;
  }

  setEngine(engine) {
    this.engine = engine;
  }
}

class VehicleBuilder {
  constructor() {
    this.vehicle = "";
  }

  getVehicle() { 
    return this.vehicle;
  };
  createNewVehicle() {
    this.vehicle = new Vehicle();
  };

  designVehicle() {};
  paintVehicle() {};
  createEngine() {};
}

class RedMitsubishiBuilder extends VehicleBuilder {
  constructor() {
    super();
  }

  designVehicle() {
    this.vehicle.setType('car');
  };
  paintVehicle() {
    this.vehicle.setColor('red');
  };
  createEngine() {
    this.vehicle.setEngine('mitsubishi engine');
  };
}

class BlueBoeingBuilder extends VehicleBuilder {
  constructor() {
    super();
  }

  designVehicle() {
    this.vehicle.setType('plane');
  };
  paintVehicle() {
    this.vehicle.setColor('blue');
  };
  createEngine() {
    this.vehicle.setEngine('boeing 707 engine');
  };
}

class Engineer {
  constructor() {
    this.vehicleBuilder;
  }

  setVehicleBuilder(builder) {
    this.vehicleBuilder = builder;
  }
  getVehicle() {
    return this.vehicleBuilder.getVehicle();
  }

  constructVehicle() {
    this.vehicleBuilder.createNewVehicle();
    this.vehicleBuilder.designVehicle();
    this.vehicleBuilder.paintVehicle();
    this.vehicleBuilder.createEngine();
  }
}

class Client {
  constructor() {
    this.engineer = new Engineer();
    this.redMitsubishiBuilder = new RedMitsubishiBuilder();
    this.blueBoeingBuilder = new BlueBoeingBuilder();
  }

  orderRedMitsubishi() {
    this.engineer.setVehicleBuilder(this.redMitsubishiBuilder);
    this.engineer.constructVehicle();
    return this.engineer.getVehicle();
  }

  orderBlueBoeing() {
    this.engineer.setVehicleBuilder(this.blueBoeingBuilder);
    this.engineer.constructVehicle();
    return this.engineer.getVehicle();
  }
}

const client = new Client();

console.log(client.orderRedMitsubishi());

console.log(client.orderBlueBoeing());