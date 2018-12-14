const expect = require('chai').expect;

function Singleton() {
  var instance;

  Singleton = function Singleton() {
    return instance;
  }

  Singleton.prototype = this;
  instance = new Singleton();
  instance.constructor = Singleton;
  instance.createObject = () => {
    instance.singletonObj = {
      objProp1: 'proppp1',
      objProp2: 'proppp2'
    }
  }

  instance.property1 = 'prop1';
  instance.property2 = 'prop2';

  return instance;
}

describe('sprawdzanie', () => {
  let singleton1 = new Singleton();
  let singleton2 = new Singleton();

  context('po utworzeniu dwoch instancji', () => {
    it('czy pola w obu instancjach są identyczne', () => {
      expect(singleton1.prop1).to.equal(singleton2.prop1);
      expect(singleton1.prop2).to.equal(singleton2.prop2);
    });

    it('czy obie instancje są rowne', () => {
      expect(singleton1).to.deep.equal(singleton2);
    })
  });

  context('po przypisaniu do klasy nowego pola', () => {
    it('czy nowe pole ma taką samą wartosc w obu instancjach', () => {
      singleton1.newField = 'nowePole';

      expect(singleton1.newField).to.equal('nowePole');
      expect(singleton2.newField).to.equal('nowePole');
    })
  })

  context('po wywołaniu metody tworzącej obiekt w jednej instancji', () => {
    singleton1.createObject();
    it('czy obie instancje mają utworzony obiekt', () => {
      expect(singleton1).to.have.deep.property('singletonObj', {
        objProp1: 'proppp1',
        objProp2: 'proppp2'
      });
      expect(singleton2).to.have.deep.property('singletonObj', {
        objProp1: 'proppp1',
        objProp2: 'proppp2'
      });
    });

    it('czy obie instancje są rowne', () => {
      expect(singleton1).to.deep.equal(singleton2);
    })
  })
});