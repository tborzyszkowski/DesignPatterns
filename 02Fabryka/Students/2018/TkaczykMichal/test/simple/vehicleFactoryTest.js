const expect = require('chai').expect;
const factory = require('../../src/simple/vehicleFactory');

describe('sprawdzanie', () => {
  context('po utworzeniu prostej fabryki i dodaniu pola', () => {
    const vehicleFactory1 = new factory.VehicleFactory();
    const vehicleFactory2 = new factory.VehicleFactory();
    vehicleFactory2.aaa = 'aaa';

    it('czy obie instancje fabryki są identyczne', () => {
      expect(vehicleFactory1).to.deep.equal(vehicleFactory2);
    });
  });

  context('po utworzeniu 3 samochodow', () => {
    const vehicleFactory = new factory.VehicleFactory();

    const car1 = vehicleFactory.createVehicle('car', { doors: 3, color: 'blue', engine: '1.8 T' });
    const car2 = vehicleFactory.createVehicle('car', { doors: 5, color: 'red', engine: '1.8 T' });
    const car3 = vehicleFactory.createVehicle('car', { doors: 4, color: 'green', engine: '1.9 TDI' });

    it('czy każdy z pojazdow jest autem', () => {
      expect(car1.type).to.equal('Car');
      expect(car2.type).to.equal('Car');
      expect(car3.type).to.equal('Car');
    });

    it('czy każde z aut posiada własności podane przy inicjalizacji', () => {
      expect(car1).to.deep.equal({
        type: 'Car',
        doors: 3,
        color: 'blue',
        engine: '1.8 T'
      });

      expect(car2).to.deep.equal({
        type: 'Car',
        doors: 5,
        color: 'red',
        engine: '1.8 T'
      });

      expect(car3).to.deep.equal({
        type: 'Car',
        doors: 4,
        color: 'green',
        engine: '1.9 TDI'
      });
    });
  });

  context('po utworzeniu 3 samolotow', () => {
    const vehicleFactory = new factory.VehicleFactory();

    const plane1 = vehicleFactory.createVehicle('plane', { seats: 260, color: 'white', engine: 'turbo engine' });
    const plane2 = vehicleFactory.createVehicle('plane', { seats: 100, color: 'black', engine: 'engine' });
    const plane3 = vehicleFactory.createVehicle('plane', { seats: 84, color: 'green', engine: 'micro engine' });

    it('czy każdy z pojazdow jest samolotem', () => {
      expect(plane1.type).to.equal('Plane');
      expect(plane2.type).to.equal('Plane');
      expect(plane3.type).to.equal('Plane');
    });

    it('czy każde z aut posiada własności podane przy inicjalizacji', () => {
      expect(plane1).to.deep.equal({
        type: 'Plane',
        seats: 260,
        color: 'white',
        engine: 'turbo engine'
      });

      expect(plane2).to.deep.equal({
        type: 'Plane',
        seats: 100,
        color: 'black',
        engine: 'engine'
      });

      expect(plane3).to.deep.equal({
        type: 'Plane',
        seats: 84,
        color: 'green',
        engine: 'micro engine'
      });
    });
  })
});