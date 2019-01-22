'use strict';

const _ = require('lodash');

class Vehicle {
  constructor(Vehicle) {}

  Clone() {}
}

class ConcreteVehicle1 extends Vehicle {
  constructor() {
    console.log("ConcreteVehicle1 created");
    super()
    this.feature = "feature 1"
    this.array = ['something in array'];
    this.object = {
      key: 'value',
      nestedObj: {
        key: 'value'
      }
    }

    this.setFeature = (key, val) => {
      this[key] = val;
    }

    this.clone = () => {
      const clone = new ConcreteVehicle1();
      console.log("ConcreteVehicle1 cloned");
      return _.cloneDeep(clone);
    }
  }
}

function init_Vehicle() {
  var proto1 = new ConcreteVehicle1();
  proto1.feature = "feature 22";
  var clone1 = proto1.clone()
  console.log('feature:', clone1.feature);
  var clone2 = clone1.clone();
  clone1.feature = 'super feature';
  console.log('clone1', clone1);
  console.log('clone2', clone2);
  console.log('\n\n');

  proto1.array.push('something new in array');
  console.log(clone1.array);

  proto1.object.nestedObj.newKey = 'newValue';
  console.log(clone1.object.nestedObj);
}

init_Vehicle();