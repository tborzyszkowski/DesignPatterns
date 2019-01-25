class Rifle {
  constructor() {
  }

  shoot() {};
  getAccuracy() {};
  getLoudness() {};
  getWeight() {};
  getRange() {};
}

class SimpleRifle extends Rifle {
  constructor() {
    super();
  }

  shoot() {
    console.log('pew pew pew');
  }

  getAccuracy() {
    return 10;
  }

  getLoudness() {
    return 160; // dB
  }

  getWeight() {
    return 3000; // g
  }

  getRange() {
    return 300; // m
  }
}

class RifleDecorator extends Rifle {
  constructor(rifle) {
    super();

    this.decoratedRifle = rifle;
  }

  shoot () {
    return this.decoratedRifle.shoot();
  };

  getAccuracy () {
    return this.decoratedRifle.getAccuracy();
  };

  getLoudness() {
    return this.decoratedRifle.getLoudness();
  };

  getWeight() {
    return this.decoratedRifle.getWeight();
  };

  getRange() {
    return this.decoratedRifle.getRange();
  };
}

class RifleWithTelescope extends RifleDecorator {
  constructor(rifle) {
    super(rifle);
  }
  
  getAccuracy() {
    return super.getAccuracy() + 10;
  }
  
  getRange() {
    return super.getRange() + 400;
  }

  getWeight() {
    return super.getWeight() + 400;
  }
}

class RifleWithGrenadeLauncher extends RifleDecorator {
  constructor(rifle) {
    super(rifle);
  }
  
  getAccuracy() {
    return super.getAccuracy() - 2;
  }

  getWeight() {
    return super.getWeight() + 1300;
  }

  getLoudness() {
    return super.getLoudness() + 50;
  }
}

// let newRifle = new SimpleRifle();

// console.log(newRifle);

// newRifle = new RifleWithTelescope(newRifle);

// console.log(newRifle);

// newRifle = new RifleWithGrenadeLauncher(newRifle);

// console.log(newRifle);

module.exports = {
  Rifle,
  SimpleRifle,
  RifleDecorator,
  RifleWithTelescope,
  RifleWithGrenadeLauncher
}